using Microsoft.Azure.Mobile.Server;

namespace QutMadSem22016Wednesday3Service.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}