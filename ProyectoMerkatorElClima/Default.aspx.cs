using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace ProyectoMerkatorElClima
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	
		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			string ciudad = txtCiudad.Text.Trim();           

			string apiKey = "8a166135e27e3fb49a52393ce4e501e0"; 

			string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={apiKey}&units=metric&lang=es";


			
			using (WebClient client = new WebClient())
			{
				
				try
				{
					
					string json = client.DownloadString(url);

					JObject datos = JObject.Parse(json);


					string temperatura = datos["main"]["temp"].ToString();

					
					string clima = datos["weather"][0]["description"].ToString();

					
					string humedad = datos["main"]["humidity"].ToString();

					
					string icono = datos["weather"][0]["icon"].ToString();

					

					lblResultado.Text = $"<strong>Ciudad:</strong> {ciudad}<br />" +
										$"<strong>Temperatura:</strong> {temperatura}°C<br />" +
										$"<strong>Clima:</strong> {clima}<br />" +
										$"<strong>Humedad:</strong> {humedad}%";

					
					imgIcono.ImageUrl = $"https://openweathermap.org/img/wn/{icono}@2x.png";
					
					imgIcono.Visible = true;
				}

				
				catch (WebException)
				{
					
					lblResultado.Text = "No se pudo obtener la información del clima. Verifique el nombre de la ciudad.";
					
					imgIcono.Visible = false;
				}
				txtCiudad.Text = string.Empty;
			}
		}

	}
}
