using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;

namespace kanavrt.Controller.Modes {
    public class EitherOrModeController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel) : AbstractModeController(kanaModel, statisticsModel, settingsModel, 2) {
        public string WrongSyllable { get; set; } = string.Empty;

        protected override void InitialMove() {
            base.InitialMove();

            int index = random.Next(0, settingsModel.characters.Count);
            CorrectSyllable = settingsModel.characters.ElementAt(index);
			settingsModel.characters.Remove(CorrectSyllable);

            index = random.Next(0, settingsModel.characters.Count);
            WrongSyllable = settingsModel.characters.ElementAt(index);

            settingsModel.characters.Add(CorrectSyllable);
        }

        protected override void NextMove() {
            if (settingsModel.characters.Count == GuessCount) {
                InitialMove();
            } else {
                string temp = CorrectSyllable;
                settingsModel.characters.Remove(CorrectSyllable);

                InitialMove();

                settingsModel.characters.Add(temp);
            }
        }
    }
}
