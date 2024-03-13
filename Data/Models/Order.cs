using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace jewellery.Data.Models
{
    public class Order
    {
        //поля необходимые для формы
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя:")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени должна быть не более 15 символов! Поле также не должно быть пустым! Пожалуйста, проверьте корректность введенных данных!")]
        public string name { get; set; }


        [Display(Name = "Введите фамилию:")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина фамилии должна быть не более 15 символов! Поле также не должно быть пустым! Пожалуйста, проверьте корректность введенных данных!")]
        public string surname { get; set; }



        [Display(Name = "Введите адрес:")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина адреса должна быть не более 15 символов! Поле также не должно быть пустым! Пожалуйста, проверьте корректность введенных данных!")]
        public string adress { get; set; }




        [Display(Name = "Введите номер телефона:")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона должна быть не более 10 символов! Поле также не должно быть пустым! Пожалуйста, проверьте корректность введенных данных!")]
        public string phone { get; set; }


        [Display(Name = "Введите имэйл:")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имейла должна быть не более 15 символов! Поле также не должно быть пустым! Пожалуйста, проверьте корректность введенных данных!")]
        public string email { get; set; }





        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
