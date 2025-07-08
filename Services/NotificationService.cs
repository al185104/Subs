using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subs.Services;

public static class NotificationService
{
    public static void ScheduleRenewalNotification(string title, string message, DateTime scheduleTime, int id)
    {
        var notification = new NotificationRequest
        {
            NotificationId = id,
            Title = title,
            Description = message,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = scheduleTime,
                Android = new Plugin.LocalNotification.AndroidOption.AndroidScheduleOptions
                {
                    AlarmType = Plugin.LocalNotification.AndroidOption.AndroidAlarmType.ElapsedRealtime
                }
            }
        };

        LocalNotificationCenter.Current.Show(notification);
    }
}
