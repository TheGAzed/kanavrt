using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;
using System;

namespace kanavrt.Controller.Quiz {
	public class ControllerError(string errorMessage, string errorSolution, int errorValue) {
		public string Message = errorMessage;
		public string Solution = errorSolution;
		public int Value = errorValue;
	}

	public abstract class AbstractQuizController {
		/// <summary>
		/// Minimum number of guesses based on mode.
		/// </summary>
		public int GuessCount { get; } = 1;
		/// <summary>
		/// The correct input during current move.
		/// </summary>
		public string CorrectSyllable { get; set; } = string.Empty;
		/// <summary>
		/// Character kanaModel to get random characters from.
		/// </summary>
		public bool isError = false;
		public ControllerError Error;
		/// <summary>
		/// Number of wrong guesses in current quiz.
		/// </summary>
		public int WrongGuesses { get; set; } = 0;
		/// <summary>
		/// Number of correct guesses in current quiz.
		/// </summary>
		public int CorrectGuesses { get; set; } = 0;
		/// <summary>
		/// Model to look up kana characters information.
		/// </summary>
		protected KanaModel kanaModel { get; }
		/// <summary>
		/// Model to look up kana statistics about correct and wrong guess count.
		/// </summary>
		protected StatisticsModel statisticsModel { get; }
		/// <summary>
		/// Model to look up kana settings like font and current characters set.
		/// </summary>
		protected SettingsModel settingsModel { get; }
		/// <summary>
		/// Class to generate random indexes to get syllables.
		/// </summary>
		protected Random random = new Random();

		public AbstractQuizController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel, int guessCount) {
			GuessCount = guessCount;
			this.kanaModel = kanaModel;
			this.statisticsModel = statisticsModel;
			this.settingsModel = settingsModel;

			if (0 == guessCount) { // guess count must be greater than 0
				throw new Exception("[ERROR01] 'guessCount' parameter can't be zero.");
			}

			if (guessCount > settingsModel.characters.Count) { // kanaModel must have at least guessCount characters to work properly
				isError = true;
				Error = new("Available input count is less than " + guessCount + '.', "Increase input count in settings to " + guessCount + " or more.", 1);
				return;
			}

			Error = new("No errors found", "No solution required", 0);

			InitialMove();
		}

		/// <summary>
		/// Initial move thet gets called by the contructor.
		/// </summary>
		protected void InitialMove() {
			if (isError) throw new("Can't call function if controller Error.");
			InitialMove_();
		}
		/// <summary>
		/// Next move that gets called by update after the user succedes/fails at guessing the correct character.
		/// </summary>
		protected void NextMove() {
			if (isError) throw new("Can't call function if controller Error.");
			NextMove_();
		}
		/// <summary>
		/// Updates the necesarry mode variables and calls NextMove_.
		/// </summary>
		/// <param name="input">Input string to check and update state with.</param>
		public void Update(string input) {
			if (isError) throw new("Can't call function if controller Error.");
			Update_(input);
		}
		/// <summary>
		/// Checks if current latin input is correct.
		/// </summary>
		/// <param name="latin">String input to check.</param>
		/// <returns>true, if latin input is correct, false otherwise</returns>
		/// 
		public bool IsCorrect(string latin) {
			if (isError) throw new("Can't call function if controller Error.");

			return IsCorrect_(latin);
		}
		/// <summary>
		/// Resets the quiz to initial state.
		/// </summary>
		public void Reset() {
			if (isError) throw new("Can't call function if controller Error.");

			Reset_();
		}

		/// <summary>
		/// Initial move thet gets called by the contructor.
		/// </summary>
		protected abstract void InitialMove_();

		/// <summary>
		/// Next move that gets called by update after the user succedes/fails at guessing the correct character.
		/// </summary>
		protected abstract void NextMove_();

		/// <summary>
		/// Updates the necesarry mode variables and calls NextMove_.
		/// </summary>
		/// <param name="input">Input string to check and update state with.</param>
		protected abstract void Update_(string input);

		/// <summary>
		/// Checks if current latin input is correct.
		/// </summary>
		/// <param name="latin">String input to check.</param>
		/// <returns>true, if latin input is correct, false otherwise</returns>
		/// 
		protected abstract bool IsCorrect_(string latin);
		/// <summary>
		/// Resets the quiz to initial state.
		/// </summary>
		protected abstract void Reset_();
	}
}
