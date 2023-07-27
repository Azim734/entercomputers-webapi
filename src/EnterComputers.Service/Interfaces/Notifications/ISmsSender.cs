using EnterComputers.Service.Dtos.Notification;

namespace EnterComputers.Service.Interfaces.Notification;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);

}
