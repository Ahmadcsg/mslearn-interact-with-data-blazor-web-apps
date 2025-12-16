namespace BlazingPizza.Services;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Pizza CurrentConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        CurrentConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    public void CancelConfigurePizzaDialog()
    {
        CurrentConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(CurrentConfiguringPizza);
        CurrentConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza pizza)
    {
        Order.Pizzas.Remove(pizza);
    }
}