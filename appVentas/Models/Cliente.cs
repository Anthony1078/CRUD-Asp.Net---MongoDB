using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace appVentas.Models
{
    public class Cliente
    {

        [BsonId,BsonRepresentation(BsonType.ObjectId)] public string codigo { get; set; }

        [BsonElement("nombre")]public string Nombre { get; set; }

        [BsonElement("direccion")]public string Direccion { get; set; }

        [BsonElement("fono")]public string Telefono { get; set; }

        [BsonElement("email")]public string email { get; set; }




    }
}