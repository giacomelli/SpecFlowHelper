//#define EN
#if EN

namespace SpecFlowHelper.Steps.Localization
{
    internal static class Locale
    {
        // Badge.
        public const string ThenShouldShowTheBadgeWithTheText = "should show the badge with the text '(.*)'";

        // Button.
        public const string WhenClickInTheButton = "click in the button '(.*)'";

        // Browser.
        public const string WhenConfirmTheAlert = "confirm the alert";

        // Checkbox.
        public const string WhenCheckTheCheckbox = "check the checkbox '(.*)'";
        public const string WhenUncheckTheCheckbox = "uncheck the checkbox '(.*)'";

        // Combobox.
        public const string WhenTypeInTheComboboxWithSearch = @"type '(.*)' in the combobox with search '(.*)'";
        public const string WhenTypeEnterInTheComboboxWithSearch = @"type enter in the combobox with search '(.*)'";
        public const string ThenTheComboboxWithSearchShouldHaveTextsSelected = @"the combobox with search '(.*)' should have '(.*)' texts selected";
        public const string WhenRemoveTheItemFromComboboxWithSearch = @"remove the item '(.*)' from the combobox with search '(.*)'";
        public const string ThenTheComboboxShouldHaveTextSelected = @"the combobox '(.*)' should have '(.*)' text selected";
        public const string WhenSelectInTheCombobox = @"select '(.*)' in the combobox '(.*)'";

        // Config.
        public const string WhenChangeWebConfigKey = @"change the web.config key '(.*)' to '(.*)'";

        // Download.
        public const string WhenClearTheDownloadsFolder = @"clear the downloads folder";
        public const string ThenShouldExistsAFileWithTheNameInTheDownloadsFolder = @"should exists a file with the name '(.*)' in the downloads folder";
        public const string ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder = @" should exists (.*) files with the extension '(.*)' in the downloads folder";

        // Grid.
        public const string ThenTheGridShouldHaveRows = @"a grid deve ter '(.*)' linhas";
        public const string WhenClickInTheFirstGridRow = @"clico na primeira linha da grid";
        public const string WhenClickInTheGridRow = @"clico na linha '(.*)' da grid";
        public const string WhenPaginateToTheNextGridPage = @"pagino a grid para a próxima página";
        public const string WhenPaginateToLastGridPage = @"pagino a grid para a última página";
        public const string WhenClickInTheGridRowWithTheText = @"clico na linha da grid com o texto '(.*)'";
        public const string WhenClickInTheRemoveButtonInTheGridRowWithTheText = @"clico no botão excluir na linha da grid com o texto '(.*)'";

        // Infrastructure.
        public const string WhenClearWebApiCache = @"clear web api cache";
        public const string WhenReinitializeDBAndServers = @"reinitialize database and servers";
        public const string WhenReinitializeDBAndServerOneTimeToFeature = @"reinitialize database and server one time to feature";
    }
}
#endif