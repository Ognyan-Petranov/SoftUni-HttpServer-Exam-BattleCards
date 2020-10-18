using BattleCards.Data;
using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(string name, string keyword, string url, int attack, int health, string description);

        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromUserCollection(string userId, int cardId);

        IEnumerable<CardViewModel> GetAllCards();

        IEnumerable<CardViewModel> GetAllCardsByUser(string id);

    }
}
