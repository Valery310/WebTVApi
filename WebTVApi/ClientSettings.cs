using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTVApi
{
    public class ClientSettings
    {
        string Stream;//Имя потока/каталога, где хранятся файлы.
        string NameClient;// Имя клиентского приложения
        string IPClient;// адрес клиентского устройства
        String ServerIP;// адрес сервера
        List<TimeOfTheDay> workerTime;// периоды рабочего времени в течении дня.
        List<DayOftheWeek> workerDay;// рабочие дни недели.
        List<Dictionary<int, MultimediaFile>> playlist; // список контента для проигрывания. Нужно реализовать возможность менять очередность воспроизведения.
        //https://stackoverflow.com/questions/5597349/how-do-i-convert-a-dictionary-to-a-json-string-in-c/13754871
        //https://json2csharp.com/
        int duratingNews;// Частота показа новостей
        bool fullscreenNews;// Показывать новости на весь экран или только на часть?
        bool orientation;// ориентация экрана;
        bool fullscreen; // Захват экрана стандартной функцией или принудительно выставить разрешение. 
        int weightScreen;// Ширина в пикселях
        int higthScreen;// Высота в пикселях
        bool downloadContent;//Скачивать ли контент для офайн режима.
        int durationUpdate;// частота проверки обновления настроек клиентом
        //параметр размера окна новостей
        TypeWork typeWork; //Тип источника. Локальный, по сети, локальный но с заказчкой из сети

    }

    public struct TimeOfTheDay
    {
        // TimeSpan dateTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));
        TimeSpan startTime;
        TimeSpan endedTime;
    }

    public enum DayOftheWeek 
    {
        Mondey,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        Everyday
    }

    public enum TypeWork
    {
        Local,
        Network,
        Mixed 
    }
}
