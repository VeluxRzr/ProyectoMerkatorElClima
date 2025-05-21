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
		//metodo,verbo o evento cuando se hace clic en el botón de búsqueda, se genera cuando creamos el boton

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			string ciudad = txtCiudad.Text.Trim();           // Obtener el texto ingresado en el TextBox y lo guarda en la variable ciudad
															 //txtCiudad.Text es el id del TextBox, donde el usuario ingresa el nombre de la ciudad
															 //Trim() elimina los espacios en blanco al principio y al final del texto ingresado
			string apiKey = "8a166135e27e3fb49a52393ce4e501e0"; // Aqui hay que reemplazar con tu propia API KEY
																//apiKey es la clave de la API de OpenWeatherMap, que permite acceder a los datos del clima de la webservidor

			//Declaracion variable tipo string $ interpolacion de cadenas
			//url es la URL de la API de OpenWeatherMap que se utiliza para obtener la información del clima
			//q={ciudad} es parametro el nombre de la ciudad ingresada por el usuario
			//&appid=apikey es el identificador único de la aplicación que se obtiene al registrarse en OpenWeatherMap
			//&units=metric especifica que la temperatura se debe mostrar en grados Celsius
			//lang=es especifica que la respuesta debe estar en español

			//es el verbo Get coleccion de estados clave= valor separados por un ampersand (&)
			string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={apiKey}&units=metric&lang=es";


			//Crea una instancia de la clase WebClient para realizar solicitudes HTTP
			//WebClient es una clase (predeterminada .NET) que proporciona métodos para enviar y recibir datos de recursos web
			using (WebClient client = new WebClient())
			{
				//Atacamos la API de OpenWeatherMap
				try
				{
					// uso el objeto client (para hacer una solicitud Get) para descargar el contenido de la URL especificada
					//DownloadString(url) descarga el contenido que devuelve esa URL como una cadena de texto
					//json es una variable que almacena la respuesta de la API en formato JSON
					string json = client.DownloadString(url);
					//jObject.Parse (json) para convertirlo en un objeto JObject / te permite manipular el JSON como un objeto
					//datos es una variable que almacena el objeto JSON parseado
					JObject datos = JObject.Parse(json);

					//Accedemos a datos extraidos de una API que devuelve informacion del clima

					//accedemos al valor de temp que esta en el objeto main y lo convierte a texto y lo guarda en la variable temperatura

					string temperatura = datos["main"]["temp"].ToString();

					//accedemos al valor description (del clima) accede a la posicion 0 del array weather y lo convierte a texto y lo guarda en la variable clima
					string clima = datos["weather"][0]["description"].ToString();

					//accedemos al valor de humidity que esta en el objeto main y lo convierte a texto y lo guarda en la variable humedad
					string humedad = datos["main"]["humidity"].ToString();

					//accedemos al valor de icon de la posicion 0 de un array y lo convierte a texto y lo guarda en la variable icono
					string icono = datos["weather"][0]["icon"].ToString();

					//accedermos a la propiedad .Text del label de nombre Resultado y le asignamos el valor de la ciudad, temperatura, clima y humedad

					//$ interpolacion de cadenas
					//<strong> etiqueta HTML que pone el texto en negrita, {variable} y <br /> es un salto de linea + (concatena

					lblResultado.Text = $"<strong>Ciudad:</strong> {ciudad}<br />" +
										$"<strong>Temperatura:</strong> {temperatura}°C<br />" +
										$"<strong>Clima:</strong> {clima}<br />" +
										$"<strong>Humedad:</strong> {humedad}%";

					//Uso de la propiedad .ImageUrl que accede al icono de la url dinamica
					//@2x.png es el tamaño del icono, alta resolucion
					imgIcono.ImageUrl = $"https://openweathermap.org/img/wn/{icono}@2x.png";
					//Uso de la propiedad .Visible para mostrar el icono
					imgIcono.Visible = true;
				}

				//Se lanza una Expcepcion si la ciudad no es válida o no se encuentra
				catch (WebException)
				{
					//Uso de la propiedad Text del label de nombre Resultado muestra un mensaje de error
					lblResultado.Text = "No se pudo obtener la información del clima. Verifique el nombre de la ciudad.";
					//Uso de la propiedad .Visible para ocultar el icono
					imgIcono.Visible = false;
				}
			}
		}

	}
}
