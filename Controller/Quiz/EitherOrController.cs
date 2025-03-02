using kanavrt.Model;
using kanavrt.Model.Statistics;
using kanavrt.Model.Settings;

namespace kanavrt.Controller.Quiz {
    public class EitherOrController(KanaModel kanaModel, StatisticsModel statisticsModel, SettingsModel settingsModel) : AbstractQuizController(kanaModel, statisticsModel, settingsModel, 2) {
        public string WrongSyllable { get; set; } = string.Empty;

        protected override void InitialMove_() {
            base.InitialMove_();

            int index = random.Next(0, settingsModel.characters.Count);
            CorrectSyllable = settingsModel.characters.ElementAt(index);
			settingsModel.characters.Remove(CorrectSyllable);

            index = random.Next(0, settingsModel.characters.Count);
            WrongSyllable = settingsModel.characters.ElementAt(index);

            settingsModel.characters.Add(CorrectSyllable);
        }

        protected override void NextMove_() {
            if (settingsModel.characters.Count == GuessCount) {
                InitialMove_();
            } else {
                string temp = CorrectSyllable;
                settingsModel.characters.Remove(CorrectSyllable);

                InitialMove_();

                settingsModel.characters.Add(temp);
            }
        }
    }
}
