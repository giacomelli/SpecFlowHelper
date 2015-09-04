#if PT
namespace SpecFlowHelper.Steps.Localization
{
    public static class Locale
    {
        public const string WhenConfirmTheAlert = "confirmo o alerta";

        public const string WhenTypeInTheComboboxWithSearch = @"digito '(.*)' na combobox com pesquisa '(.*)'";
        public const string WhenTypeEnterInTheComboboxWithSearch = @"teclo enter na combobox com pesquisa '(.*)'";
        public const string ThenTheComboboxWithSearchShouldHaveTextsSelected = @"a combobox de pesquisa '(.*)' deve ter os textos '(.*)' selecionados";
        public const string WhenRemoveTheItemFromComboboxWithSearch = @"remove o item '(.*)' da combobox com pesquisa '(.*)'";
        public const string ThenTheComboboxShouldHaveTextSelected = @"a combobox '(.*)' deve ter o texto '(.*)' selecionado";
        public const string WhenSelectInTheCombobox = @"seleciono '(.*)' na combobox '(.*)'";
    }
}
#endif