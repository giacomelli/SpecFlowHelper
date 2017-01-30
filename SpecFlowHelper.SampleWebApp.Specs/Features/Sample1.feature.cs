﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class Sample1Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Sample1.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-br"), "Sample1", "\tCOMO usuário\r\n\tQUERO acessar a página incial\r\n\tPARA mostrar o uso do SpecFlowHel" +
                    "per", ProgrammingLanguage.CSharp, new string[] {
                        "Home"});
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
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Sample1")))
            {
                SpecFlowHelper.SampleWebApp.Specs.Features.Sample1Feature.FeatureSetup(null);
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
 testRunner.When("acesso a página principal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Quando acesso a página principal")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sample1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Home")]
        public virtual void QuandoAcessoAPaginaPrincipal()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quando acesso a página principal", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 12
 testRunner.Then("deve exibir o texto \'Index view\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Quando digito no campo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sample1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Home")]
        public virtual void QuandoDigitoNoCampo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quando digito no campo", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 15
 testRunner.When("digito \'SpecFlowHelper sample\' no campo \'input1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 16
 testRunner.And("clico no botão \'Enviar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 17
 testRunner.Then("o campo \'input1\' deve ter o valor \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Quando inicio os jobs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sample1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Home")]
        public virtual void QuandoInicioOsJobs()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Quando inicio os jobs", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 20
 testRunner.When("digito \'Verificando SampleJob1\' no campo \'input1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 21
 testRunner.And("executo o job \'SampleJob1\' e aguardo pelo texto \'SampleJob1 done\' no log", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 22
 testRunner.Then("existe o texto \'Starting SampleJob1\' no log do job", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 24
 testRunner.When("digito \'Verificando SampleJob2\' no campo \'input1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line 25
 testRunner.And("executo o job \'SampleJob2\' e aguardo pelo texto \'SampleJob2 done\' no log", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line 26
 testRunner.Then("existe o texto \'Starting SampleJob2\' no log do job", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line 28
 testRunner.When("digito \'Jobs ok\' no campo \'input1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quando ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
