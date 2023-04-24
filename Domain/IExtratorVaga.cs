using AngleSharp.Html.Parser;
using CoderCarrer.Models;
using HtmlAgilityPack;
using System.Collections;
using System.Text;

namespace CoderCarrer.Domain
{
    public interface IExtratorVaga : IEnumerable
    {
        public List<Vaga> getVagas();

    }
}
