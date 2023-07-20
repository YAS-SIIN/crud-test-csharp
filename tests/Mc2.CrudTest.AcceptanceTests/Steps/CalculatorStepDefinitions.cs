namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("to be filled...")]
    public void GivenTheFirstNumberIs(int number)
    {

        _scenarioContext.Pending();
    }

    [When("to be filled...")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic

        _scenarioContext.Pending();
    }

    [Then("to be filled...")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic

        _scenarioContext.Pending();
    }
}