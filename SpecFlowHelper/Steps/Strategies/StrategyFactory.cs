using Skahal.Infrastructure.Framework.Commons;
using SpecFlowHelper.Steps.Strategies.AngularJS;
using SpecFlowHelper.Steps.Strategies.Default;

namespace SpecFlowHelper.Steps.Strategies
{
    /// <summary>
    /// The strategies factory.
    /// </summary>
    public static class StrategyFactory
    {
        #region Constructors
        /// <summary>
        /// Initializes the <see cref="StrategyFactory"/> class.
        /// </summary>
        static StrategyFactory()
        {
            Register<IBrowserStepsStrategy, BrowserSteps>(new DefaultBrowserStepsStrategy());
            Register<IUploadStepsStrategy, UploadSteps>(new DefaultUploadStepsStrategy());
            Register<IComboboxStepsStrategy, ComboboxSteps>(new AngularJSComboboxStepsStrategy());
        }
        #endregion

        #region Methods
        public static void Register<TStrategy, TSteps>(TStrategy strategy)
            where TStrategy : IStepsStrategy<TSteps>
            where TSteps : StepsBase
        {
            DependencyService.Register<TStrategy>(strategy);
        }

        public static TStrategy Create<TStrategy, TSteps>(TSteps steps)
            where TStrategy : IStepsStrategy<TSteps>
            where TSteps : StepsBase
        {
            var strategy = DependencyService.Create<TStrategy>();
            strategy.CurrentSteps = steps;

            return strategy;
        }
        #endregion
    }
}
