using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertService
{
    public interface IAlertDAO
    {
        Guid AddAlert(DateTime time);

        DateTime GetAlert(Guid id);
    }
    public class AlertService
    {
        private readonly AlertDAO storage = new AlertDAO();

        public AlertService(IAlertDAO alertDAO)
        {
            this.storage = (AlertDAO)alertDAO;
        }
        public Guid RaiseAlert()
        {
            return this.storage.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return this.storage.GetAlert(id);
        }
    }

    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
