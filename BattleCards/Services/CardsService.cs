﻿using BattleCards.Data;
using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService userService;

        public CardsService(ApplicationDbContext db, IUsersService userService)
        {
            this.db = db;
            this.userService = userService;
        }

        public int AddCard(string name, string url, string keyword, int attack, int health, string description)
        {
            var card = new Card
            {
                Attack = attack,
                Health = health,
                Description = description,
                Name = name,
                ImageUrl = url,
                Keyword = keyword,
            };
            this.db.Cards.Add(card);
            this.db.SaveChanges();
            return card.CardId;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });
            this.db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAllCards()
        {
            var allCards = this.db.Cards.Select(x => new CardViewModel()
            {
                CardId = x.CardId,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description
            }).ToList();

            return allCards;
        }

        public IEnumerable<CardViewModel> GetAllCardsByUser(string id)
        {
            var allUserCards = this.db.UserCards.Where(x => x.UserId == id)
                .Select(x => new CardViewModel()
                {

                    CardId = x.Card.CardId,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Keyword = x.Card.Keyword,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description
                }).ToList();

            return allUserCards;
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}
