#if PT
namespace SpecFlowHelper.Steps.Localization
{
    internal static class Locale
    {
        // Badge.
        public const string ThenShouldShowTheBadgeWithTheText = "deve exibir o badge com o texto '(.*)'";

        // Button.
        public const string WhenClickInTheButton = "clico no botão '(.*)'";

        // Browser.
        public const string WhenConfirmTheAlert = "confirmo o alerta";

        // Checkbox.
        public const string WhenCheckTheCheckbox = "marco a checkbox '(.*)'";
        public const string WhenUncheckTheCheckbox = "desmarco a checkbox '(.*)'";

        // RadioButton.
        public const string WhenCheckTheRadioButton = "marco o radiobutton '(.*)'";


        // Combobox.
        public const string WhenTypeInTheComboboxWithSearch = @"digito '(.*)' na combobox com pesquisa '(.*)'";
        public const string WhenTypeEnterInTheComboboxWithSearch = @"teclo enter na combobox com pesquisa '(.*)'";
        public const string ThenTheComboboxWithSearchShouldHaveTextsSelected = @"a combobox de pesquisa '(.*)' deve ter os textos '(.*)' selecionados";
        public const string WhenRemoveTheItemFromComboboxWithSearch = @"remove o item '(.*)' da combobox com pesquisa '(.*)'";
        public const string ThenTheComboboxShouldHaveTextSelected = @"a combobox '(.*)' deve ter o texto '(.*)' selecionado";
        public const string WhenSelectInTheCombobox = @"seleciono '(.*)' na combobox '(.*)'";

        // Config.
        public const string WhenChangeWebConfigKey = @"altero a chave '(.*)' do web\.config para '(.*)'";

        // Download.
        public const string WhenClearTheDownloadsFolder = @"limpo a pasta de downloads do usuário";
        public const string ThenShouldExistsAFileWithTheNameInTheDownloadsFolder = @"deve existir um arquivo com o nome '(.*)' na pasta de downloads";
        public const string ThenShouldExistsFilesWithTheExtensionInTheDownloadsFolder = @"deve existir (.*) arquivos com a extensão '(.*)' na pasta de downloads";

        // Grid.
        public const string ThenTheGridShouldHaveRows = @"a grid deve ter '(.*)' linhas";
        public const string WhenClickInTheFirstGridRow = @"clico na primeira linha da grid";
        public const string WhenClickInTheGridRow = @"clico na linha '(.*)' da grid";
        public const string WhenPaginateToTheNextGridPage = @"pagino a grid para a próxima página";
        public const string WhenPaginateToThePreviousGridPage = @"pagino a grid para a página anterior";        
        public const string WhenPaginateToLastGridPage = @"pagino a grid para a última página";
        public const string WhenPaginateToFirstGridPage = @"pagino a grid para a primeira página";
        public const string WhenClickInTheGridRowWithTheText = @"clico na linha da grid com o texto '(.*)'";
        public const string WhenClickInTheRemoveButtonInTheGridRowWithTheText = @"clico no botão excluir na linha da grid com o texto '(.*)'";
        public const string WhenSortTheGridByColumn = @"orderno a grid pela coluna '(.*)'";

        // Infrastructure.
        public const string WhenClearWebApiCache = @"limpo o cache da web api";
        public const string WhenReinitializeDBAndServers = @"reinicializo banco e servidores";
        public const string WhenReinitializeDBAndServerOneTimeToFeature = @"reinicializo banco e servidores uma única vez para toda a feature";
    }
}
#endif