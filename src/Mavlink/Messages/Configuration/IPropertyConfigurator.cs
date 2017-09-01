namespace Mavlink.Messages.Configuration
{
    public interface IPropertyConfigurator
    {
        IPropertyConfigurator SetName(string name);

        IPropertyConfigurator SetOrder(int order);

        IPropertyConfigurator SetSize(int size);


    }
}