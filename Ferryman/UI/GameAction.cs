using Ferryman.Models;
using Ferryman.Service;
using Ferryman.UI.Components;
using System;

namespace Ferryman.UI
{
    public class GameAction
    {
        private readonly IGameService game;

        private bool _isExitGameMenu = false;

        public GameAction()
        {
            game = new GameService();

        }

        public void BeginGame()
        {
            GameText.Rules.ShowOnConsole();
            ShowComponents.Pause();

            ShowComponents.ShowArea(game.RightCoast, game.LeftCoast);
            ShowComponents.ShowBoatPlace(game.Boat);

            while (!_isExitGameMenu)
            {
                ShowComponents.ShowGameActionMenu();
                var key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case '1':
                        Action(game.Wolf);
                        break;
                    case '2':
                        Action(game.Goat);
                        break;
                    case '3':
                        Action(game.Cabbage);
                        break;
                    case '4':
                        game.Boat.BoatPlace = !game.Boat.BoatPlace;
                        CheckAction();
                        break;
                    case '0':
                        _isExitGameMenu = true;
                        break;
                    default:
                        break;
                }

            }
        }

        private void Action(IPassenger passenger)
        {
            if (game.Boat.BoatPlace)
            {
                game.ActionRemoveFromArea(game.RightCoast, passenger);
                game.ActionAddToArea(game.LeftCoast, passenger);
            }
            else
            {
                game.ActionRemoveFromArea(game.LeftCoast, passenger);
                game.ActionAddToArea(game.RightCoast, passenger);
            }

            game.Boat.BoatPlace = !game.Boat.BoatPlace;

            CheckAction();
        }

        private void CheckAction()
        {
            ShowComponents.ShowArea(game.RightCoast, game.LeftCoast);
            ShowComponents.ShowBoatPlace(game.Boat);

            game.Count++;
            bool chekAction;
            bool boatPlase = game.Boat.BoatPlace;
            if (boatPlase)
                chekAction = game.CheckResult(game.LeftCoast);
            else
                chekAction = game.CheckResult(game.RightCoast);

            if (!chekAction)
            {
                var errorList = boatPlase ? game.LeftCoast : game.RightCoast;

                ShowComponents.ShowGameOverMessage(errorList);
                _isExitGameMenu = true;
            }
            if (game.LeftCoast.Count == 3 && game.RightCoast.Count == 0)
            {
                ShowComponents.ShowGameWinMessage(game.Count);
                _isExitGameMenu = true;
            }
        }
    }
}
