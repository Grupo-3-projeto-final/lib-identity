using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityGama.ModelViews
{
    public struct ApiError
    {
        [JsonPropertyName("Mensagem")]
        public string Message { get; set; }

        [JsonPropertyName("CodigoDeStatusHttp")]
        public int StatusCode { get; set; }
    }
}
