﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowHelper.SampleWebApp.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class IFrameFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "IFrame.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "IFrame", "COMO usuário\r\nQUERO acessar a página de teste de IFrames\r\nPARA validar os passos", ProgrammingLanguage.CSharp, new string[] {
                        "Browser"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "IFrame")))
            {
                SpecFlowHelper.SampleWebApp.Specs.Features.IFrameFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 8
#line 9
 testRunner.When("abro a url \'Home/WindowWithIframes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Quando navega para o iframe")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "IFrame")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Browser")]
        public virtual void QuandoNavegaParaOIframe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quando navega para o iframe", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 12
 testRunner.When("navego para o iframe \'IFrameFast\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 13
 testRunner.Then("deve exibir o texto \'IFrameFast\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 15
 testRunner.When("navego de volta para a janela principal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 17
 testRunner.When("navego para o iframe \'IFrameSlow1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 18
 testRunner.Then("deve exibir o texto \'IFrameSlow1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 19
 testRunner.When("clico no botão \'Abrir IFrameSlow2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 20
 testRunner.Then("deve exibir o texto \'IFrameSlow2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
