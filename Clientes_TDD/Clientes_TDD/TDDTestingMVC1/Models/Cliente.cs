using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC1.Models
{
    public class Cliente
    {
        [Required]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener 10 dígitos.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La cédula solo debe contener números.")]
        [CustomValidation(typeof(Cliente), nameof(ValidarCedulaEcuatoriana))]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(50, ErrorMessage = "Los apellidos no pueden superar los 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(50, ErrorMessage = "Los nombres no pueden superar los 50 caracteres.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Cliente), nameof(ValidarFechaNacimiento))]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El teléfono debe tener 10 dígitos.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "El teléfono debe contener exactamente 10 dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
        public string Direccion { get; set; }

        [Required]
        public bool Estado { get; set; }

        // Relación con Pedido (Uno a muchos)
        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        // Validación de la fecha de nacimiento
        public static ValidationResult ValidarFechaNacimiento(DateTime fechaNacimiento, ValidationContext context)
        {
            DateTime hoy = DateTime.Today;
            DateTime fechaMinima = hoy.AddYears(-100);
            DateTime fechaMaxima = hoy;

            if (fechaNacimiento < fechaMinima)
            {
                return new ValidationResult($"La fecha de nacimiento no puede ser menor a {fechaMinima:dd/MM/yyyy}.");
            }

            if (fechaNacimiento > fechaMaxima)
            {
                return new ValidationResult("La fecha de nacimiento no puede ser una fecha futura.");
            }

            return ValidationResult.Success;
        }

        // Validación de cédula ecuatoriana
        public static ValidationResult ValidarCedulaEcuatoriana(string cedula, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(cedula) || cedula.Length != 10 || !int.TryParse(cedula, out _))
            {
                return new ValidationResult("La cédula debe contener exactamente 10 números.");
            }

            int total = 0;
            for (int i = 0; i < 9; i++)
            {
                int num = int.Parse(cedula[i].ToString());
                if (i % 2 == 0)
                {
                    num *= 2;
                    if (num > 9) num -= 9;
                }
                total += num;
            }

            int digitoVerificador = (total % 10 == 0) ? 0 : (10 - (total % 10));
            if (digitoVerificador != int.Parse(cedula[9].ToString()))
            {
                return new ValidationResult("La cédula ingresada no es válida.");
            }

            return ValidationResult.Success;
        }
    }
}
