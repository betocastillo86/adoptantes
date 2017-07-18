//-----------------------------------------------------------------------
// <copyright file="SeedNotification.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Migrations.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Adopters.Data.Core;
    using Adopters.Data.Entities;

    /// <summary>
    /// Seeds notifications
    /// </summary>
    public static class SeedNotification
    {
        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Seed(AdoptersContext context)
        {
            var list = new List<Notification>();
            list.Add(new Notification() { Id = Convert.ToInt32(NotificationType.Welcome), Name = "Registro de usuario", Active = true, IsEmail = true, IsSystem = false, SystemText = null, Tags = "[{ \"key\":\"%%NotifiedUser.Name%%\",\"value\":\"Nombre del usuario\" },{ \"key\":\"%%NotifiedUser.Email%%\",\"value\":\"Correo del usuario notificado\" },{\"key\":\"%%Url%%\" , \"value\": \"Link principal\"}]", EmailSubject = "Bienvenido a Huellitas sin hogar", EmailHtml = "<h2 style=\"color: #304a6f;text-align: center;font-size: 22px;\"><b>!Nos alegra mucho que te hayas unido a Huellitas sin Hogar!</b></h2>                     <p><br></p>                     <p>Hola %%NotifiedUser.Name%%,</p>                     <p>queremos comunicarte que el perfil ya está creado en nuestra pagina y podrás empezar a:</p> <ul> 	<li><a href=\"%%RootUrl%%/sinhogar\" target=\"\">​Llenar formularios de adopción</a></li> 	<li><a href=\"%%RootUrl%%perdidos/crear\" target=\"\">Reportar mascotas perdidas</a></li> 	<li><a href=\"%%RootUrl%%dar-en-adopcion\" target=\"\">Dar en adopción perros y gatos</a></li> 	<li><a href=\"%%RootUrl%%/fundaciones/crear\" target=\"\">Registrar tu fundación o hogar de paso</a></li> </ul> <p>Muchas gracias por apoyar a las huellitas sin hogar.</p>                     <p><a href=\"%%RootUrl%%\" style=\"color: #FFF; background: #3C75C2; font-size: 20px;  text-decoration: none; margin: 10px auto; display: block; min-width: 140px; text-align: center; border-radius: 6px; padding: 10px 0;\">Ir a Huellitas sin Hogar</a></p>" });
            list.Add(new Notification() { Id = Convert.ToInt32(NotificationType.NewCommentOnReport), Name = "Comentario en contenido creado", Active = true, IsEmail = true, IsSystem = false, SystemText = "%%TriggerUser.Name%% ha comentado <b>%%Report.Name%%</b>", Tags = "[{ \"key\":\"%%NotifiedUser.Name%%\",\"value\":\"Nombre del usuario\" },{ \"key\":\"%%NotifiedUser.Email%%\",\"value\":\"Correo del usuario notificado\" },{ \"key\":\"%%TriggerUser.Name%%\",\"value\":\"Nombre del usuario que realiza acción\" },{ \"key\":\"%%TriggerUser.Email%%\",\"value\":\"Correo del usuario que realiza acción\" },{\"key\":\"%%Url%%\" , \"value\": \"Link principal\"},{\"key\":\"%%Report.Name%%\", \"value\":\"Nombre del contenido\"},{\"key\":\"%%Report.Url%%\", \"value\":\"Link del contenido\"}]", EmailSubject = "%%TriggerUser.Name%% ha comentado %%Report.Name%%", EmailHtml = "<h2 style=\"color: #304a6f;text-align: center;font-size: 22px;\"><b>Han comentado %%Report.Name%%</b></h2> <p style=\"text-align: left;\"><br></p> <p style=\"text-align: left;\">Hola %%NotifiedUser.Name%%, mira que han dicho de %%Report.Name%% aquí.</p> <p></p> <p><a href=\"%%Report.Url%%\" style=\"color: #FFF; background: #3C75C2; font-size: 20px; text-decoration: none; margin: 10px auto; display: block; min-width: 140px; text-align: center; border-radius: 6px; padding: 10px 0;\">Ver comentario</a></p> <p>Muchas gracias por apoyar a las huellitas sin hogar.<br></p>" });
            list.Add(new Notification() { Id = Convert.ToInt32(NotificationType.NewSubcommentOnMyComment), Name = "Subcomentario en mi comentario", Active = true, IsEmail = true, IsSystem = false, SystemText = "Han respondido tu comentario sobre %%Report.Name%%", Tags = "[{ \"key\":\"%%NotifiedUser.Name%%\",\"value\":\"Nombre del usuario\" },{ \"key\":\"%%NotifiedUser.Email%%\",\"value\":\"Correo del usuario notificado\" },{ \"key\":\"%%TriggerUser.Name%%\",\"value\":\"Nombre del usuario que realiza acción\" },{ \"key\":\"%%TriggerUser.Email%%\",\"value\":\"Correo del usuario que realiza acción\" },{\"key\":\"%%Url%%\" , \"value\": \"Link principal\"},{\"key\":\"%%Report.Name%%\", \"value\":\"Nombre del contenido\"},{\"key\":\"%%Report.Url%%\", \"value\":\"Link del contenido\"}]", EmailSubject = "Han respondido tu comentario sobre %%Report.Name%%", EmailHtml = "<h2 style=\"color: #304a6f;text-align: center;font-size: 22px;\"><b>Han respondido tu comentario en &nbsp;%%Report.Name%%</b></h2> <p style=\"text-align: left;\"><br></p> <p style=\"text-align: left;\">Hola %%NotifiedUser.Name%%, mira que han dicho de %%Report.Name%% aquí.</p> <p></p> <p><a href=\"%%Report.Url%%\" style=\"color: #FFF; background: #3C75C2; font-size: 20px; text-decoration: none; margin: 10px auto; display: block; min-width: 140px; text-align: center; border-radius: 6px; padding: 10px 0;\">Ver comentario</a></p> <p>Muchas gracias por apoyar a las huellitas sin hogar.<br></p>" });
            list.Add(new Notification() { Id = Convert.ToInt32(NotificationType.NewSubcommentOnSomeoneElseComment), Name = "Subcomentario en el comentario de otro", Active = true, IsEmail = true, IsSystem = false, SystemText = "Han comentado algo que comentaste", Tags = "[{ \"key\":\"%%NotifiedUser.Name%%\",\"value\":\"Nombre del usuario\" },{ \"key\":\"%%NotifiedUser.Email%%\",\"value\":\"Correo del usuario notificado\" },{ \"key\":\"%%TriggerUser.Name%%\",\"value\":\"Nombre del usuario que realiza acción\" },{ \"key\":\"%%TriggerUser.Email%%\",\"value\":\"Correo del usuario que realiza acción\" },{\"key\":\"%%Url%%\" , \"value\": \"Link principal\"},{\"key\":\"%%Report.Name%%\", \"value\":\"Nombre del contenido\"},{\"key\":\"%%Report.Url%%\", \"value\":\"Link del contenido\"}]", EmailSubject = "Han comentado algo que comentaste", EmailHtml = "<h2 style=\"color: #304a6f;text-align: center;font-size: 22px;\"><b>Han respondido en un comentario</b></h2> <p style=\"text-align: left;\"><br></p> <p style=\"text-align: left;\">Hola %%NotifiedUser.Name%%, mira que han dicho de %%Report.Name%% aquí.</p> <p></p> <p><a href=\"%%Report.Url%%\" style=\"color: #FFF; background: #3C75C2; font-size: 20px; text-decoration: none; margin: 10px auto; display: block; min-width: 140px; text-align: center; border-radius: 6px; padding: 10px 0;\">Ver comentario</a></p> <p>Muchas gracias por apoyar a las huellitas sin hogar.<br></p>" });

            foreach (var item in list)
            {
                if (!context.Notifications.Any(c => c.Id.Equals(item.Id)))
                {
                    context.Notifications.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}