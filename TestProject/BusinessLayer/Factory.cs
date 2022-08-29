using System;
using TestProject.Models;

namespace TestProject.BusinessLayer
{
    public abstract class Factory
    {
        protected static Stack<Coordinate> Plays { get; set; }
        protected static IList<Coordinate> LandingRockets { get; set; }

        protected static Coordinate TopLeftLadingPlataform;
        protected static Coordinate TopRigthtLadingPlataform;
        protected static Coordinate BottomLeftLadingPlataform;
        protected static Coordinate BottomRigthtLadingPlataform;

        #region Configurations

        public static void StarConfigurations(Coordinate topLeftLadingPlataform, Coordinate topRigthtLadingPlataform, Coordinate bottomLeftLadingPlataform, Coordinate bottomRigthtLadingPlataform)
        {
            Plays = new Stack<Coordinate>();
            LandingRockets = new List<Coordinate>();

            TopLeftLadingPlataform = topLeftLadingPlataform;
            TopRigthtLadingPlataform = topRigthtLadingPlataform;
            BottomLeftLadingPlataform = bottomLeftLadingPlataform;
            BottomRigthtLadingPlataform = bottomRigthtLadingPlataform;
        }

        #endregion

        #region Landing Rockets

        protected static void AddRocket(Coordinate coordinate)
        {
            LandingRockets.Add(coordinate);
        }

        protected static bool AlreadyHasRocketOnThatLocation(Coordinate coordinate)
        {
            return LandingRockets.Any(l => l.X == coordinate.X && l.Y == coordinate.Y);
        }

        protected static bool AlreadyHasRocketNearBy(Coordinate coordinate)
        {
            return LandingRockets.Any(l => ((l.X + 1) == coordinate.X || (l.X - 1) == coordinate.X) && ((l.Y + 1) == coordinate.Y || (l.Y - 1) == coordinate.Y));
        }

        #endregion

        #region Plays

        protected static void AddPlay(Coordinate coordinate)
        {
            Plays.Push(coordinate);
        }

        protected static Coordinate GetLastPlay()
        {
            return Plays == null || !Plays.Any() ? null : Plays.Peek();
        }

        public static string Play(Coordinate coordinate)
        {
            if (coordinate != null)
            {
                var lastPlay = GetLastPlay();

                if (lastPlay != null)
                {
                    // Clash, last play is equals
                    if (lastPlay.Equals(coordinate))
                    {
                        AddPlay(coordinate);

                        return Constants.LandingResultsOptions[0];
                    }

                    // Clash, last play is located next to a last position requested
                    if ((lastPlay.X + 1) == coordinate.X
                     || (lastPlay.X - 1) == coordinate.X
                     || (lastPlay.Y + 1) == coordinate.Y
                     || (lastPlay.Y - 1) == coordinate.Y)
                    {
                        AddPlay(coordinate);

                        return Constants.LandingResultsOptions[0];
                    }
                }

                // out of plataform
                if (!IsPlayInnerLandingPlataform(coordinate))
                {
                    AddPlay(coordinate);

                    return Constants.LandingResultsOptions[-1];
                }
                else
                {
                    // ok for landing
                    AddPlay(coordinate);

                    // Clash, last play is equals
                    if (AlreadyHasRocketOnThatLocation(coordinate))
                    {
                        return Constants.LandingResultsOptions[0];
                    }

                    // validate near position is valid
                    if (AlreadyHasRocketNearBy(coordinate))
                    {
                        return Constants.LandingResultsOptions[0];
                    }

                    AddRocket(coordinate);

                    return Constants.LandingResultsOptions[1];
                }
            }

            return null;
        }

        protected static bool IsPlayInnerLandingPlataform(Coordinate coordinate)
        {
            if (coordinate.X >= TopLeftLadingPlataform.X
                && coordinate.X <= TopRigthtLadingPlataform.X
                && coordinate.Y >= TopLeftLadingPlataform.Y
                && coordinate.Y <= BottomLeftLadingPlataform.Y
                )
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}

