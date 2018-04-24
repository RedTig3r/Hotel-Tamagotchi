using HotelTamagotchi.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelTamagotchi.Models.ViewModel
{
    public class PlayerUserVM
    {

        private PlayerUser _playerUser;

        public PlayerUserVM()
        {
            this._playerUser = new PlayerUser();
        }

        public PlayerUserVM(PlayerUser playerUser)
        {
            this._playerUser = playerUser;
        }

        internal PlayerUser ToModel()
        {
            return _playerUser;
        }

        [Key]
        [Required]
        [DisplayName("Tamagotchi Id")]
        public int PlayerUserId
        {
            get { return _playerUser.PlayerUserId; }
            set { _playerUser.PlayerUserId = value; }
        }

        [Required]
        [DisplayName("Player UserName")]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string PlayerUserName
        {
            get { return _playerUser.PlayerUserName; }
            set { _playerUser.PlayerUserName = value; }
        }

        [Required]
        [DisplayName("Player user roll")]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string PlayerUserRoll
        {
            get { return _playerUser.PlayerUserRoll; }
            set { _playerUser.PlayerUserRoll = value; }
        }

        [DisplayName("Tamagotchis ids")]
        public int[] TamagotchisIds { get; set; }


        [DisplayName("Player tamagotchis")]
        public ICollection<Tamagotchi> Tamagotchis
        {
            get { return _playerUser.Tamagotchis; }
            set { _playerUser.Tamagotchis = value; }
        }

    }
}