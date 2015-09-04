// #define EN
#if EN

namespace SpecFlowHelper.Steps.Localization
{
    public static class Locale
    {
        public const string WhenConfirmTheAlert = "confirm the alert";

        public const string WhenTypeInTheComboboxWithSearch = @"type '(.*)' in the combobox with search '(.*)'";
        public const string WhenTypeEnterInTheComboboxWithSearch = @"type enter in the combobox with search '(.*)'";
        public const string ThenTheComboboxWithSearchShouldHaveTextsSelected = @"the combobox with search '(.*)' should have '(.*)' texts selected";
        public const string WhenRemoveTheItemFromComboboxWithSearch = @"remove the item '(.*)' from the combobox with search '(.*)'";
        public const string ThenTheComboboxShouldHaveTextSelected = @"the combobox '(.*)' should have '(.*)' text selected";
        public const string WhenSelectInTheCombobox = @"select '(.*)' in the combobox '(.*)'";
    }
}
#endif