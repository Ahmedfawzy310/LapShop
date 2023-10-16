namespace TripIoO.Services.Interfaces
{
    public interface ISetting
    {
        TbSetting? Get();
        bool Save(TbSetting set);
    }
}
