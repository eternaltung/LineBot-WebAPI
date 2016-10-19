using System.Threading.Tasks;
using LineBot.Models;

namespace LineBot.BLL
{
    public interface ILineHandler
    {
        Task ProcessMessage(WebhookModel value);
    }
}
