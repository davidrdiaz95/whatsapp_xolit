using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xolit.Herramientas.Utilidad.Consumo;
using Xolit.Modelos.DTO.Consumo;
using Xolit.Whatsapp.Contracts.Commands.Whatsapp;
using Xolit.Whatsapp.DataTransferObjects.Models.Whatsapp;

namespace Xolit.Whatsapp.Domain.Commands.Whatsapp
{
    public class SendMessageWhatsappCommand : ISendMessageWhatsappCommand
    {
        public async Task<bool> Execute(RequestSendMessageDTO requestSendMessage)
        {
            var headers = new Dictionary<string, string>();

            headers.Add("Content-Type", "application/json");
            headers.Add("Authorization", "Bearer ACCESS_TOKEN");
            var consumption = new ConfiguracionConsumoGenericoApi<string>();
            consumption.UrlConsumo = "https://graph.facebook.com/v12.0/FROM_PHONE_NUMBER_ID/messages";
            consumption.TipoConsumo = HttpMethod.Get;
            consumption.CuerpoConsulta = JsonSerializer.Serialize(requestSendMessage);
            consumption.TieneCuerpo = true;
            var response = await GenericosConsumo.RealizarConsulta(consumption);
            return response.CodigoStatus == 0? true:false;
        }
    }
}
