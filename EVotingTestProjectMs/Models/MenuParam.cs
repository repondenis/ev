namespace EVotingTestProjectMs.Models
{
    class MenuParam
    {
        public const string organizators = "Для организаторов";
        public const string securities = "Для владельцев ценных бумаг";
        public const string registrators = "Для регистраторов";
        public const string observers = "Для наблюдателей'";
    }

    class LoginParam
    {
        public const string esia = "ЕСИА";
        public const string login = "логин/пароль";
        public const string sertif = "сертификат";
    }

    /** 
     * статус собрания
     */
    class MeetingStatusFilter
    {
        public const string itemSelect = "Выберите";
        public const string itemLoadMN = "Загружено из MN";
        public const string itemMeetOpen = "Создано общее собрание";
        public const string itemOpenEmitentRegistr = "Открыто эмитенту и регистратору";
        public const string itemImportPOrtal = "Перенесено на портал голосования";
        public const string itemTurn = "В очереди на обработку";
        public const string itemRefresh = "Обновляется";
        public const string itemFreePublic = "Опубликовано общее собрание";
        public const string itemZaoResultsOpen = "Доступно заочное голосование на собрании";
        public const string itemZaoResultsComplete = "Заочное голосование завершено";
        public const string itemRegisterOpen = "Открыта регистрация на собрании, доступно голосование на собрании";
        public const string itemRegisterComplete = "Регистрация на собрании завершена, доступно голосование на собрании";
        public const string itemResults = "Голосование на собрании завершено, подводятся итоги собрания";
        public const string itemResultsPublic = "Опубликованы итоги собрания";
        public const string itemMeetComplete = "Собрание завершено";
        public const string itemArchive = "Перенесено в архив";
        public const string itemCancel = "Отменено";
    }

    class MeetingMethodCreate
    {
        public const string MANUAL = "Вручную";
        public const string FILE = "Из файла";
        public const string MN = "Из загруженных";
    }


    class securityType
    {
        public const string akcii = "Акции";
        public const string pai = "Паи";
        public const string obligation = "Облигации";
        public const string ipotekSert = "Ипотечные сертификаты";
    }

    class meetingType
    {
        public const string years = "Годовое собрание акционеров";
        public const string extra = "Внеочередное общее собрание акционеров";
    }



    class formType
    {
        public const string sendList = "Собрание (предусмотрена возможность направления заполненных бюллетеней)";
        public const string notSendList = "Собрание (не предусмотрена возможность направления заполненных бюллетеней)";
        public const string absentBallot = "Заочное голосование";

    }

}
