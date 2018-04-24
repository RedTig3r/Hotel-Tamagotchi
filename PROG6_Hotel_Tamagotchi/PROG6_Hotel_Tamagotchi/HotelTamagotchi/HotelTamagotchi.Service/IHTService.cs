using HotelTamagotchi.Domain.Model;
using HotelTamagotchi.Service.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelTamagotchi.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHTService
    {
      
        [OperationContract]
        ICollection<PlayerUserContract> PlayerUserGetAll();

        [OperationContract]
        ICollection<PlayerUserContract> PlayerUserGetAllWhereId(int? id);

        [OperationContract]
        PlayerUserContract PlayerUserGetWhereId(int? id);

        [OperationContract]
        void PlayerUserAdd(PlayerUserContract contract);

        [OperationContract]
        void PlayerUserEdit(PlayerUserContract contract);

        [OperationContract]
        void PlayerUserDelete(PlayerUserContract contract);


        [OperationContract]
        ICollection<TamagotchiContract> TamagotchiGetAll();

        [OperationContract]
        ICollection<TamagotchiContract> TamagotchiGetAllWhereId(int? id);

        [OperationContract]
        TamagotchiContract TamagotchiGetWhereId(int? id);

        [OperationContract]
        void TamagotchiAdd(TamagotchiContract contract);

        [OperationContract]
        void TamagotchiEdit(TamagotchiContract contract);

        [OperationContract]
        void TamagotchiDelete(TamagotchiContract contract);



      

        [OperationContract]
        ICollection<HotelRoomContract> HotelRoomGetAll();

        [OperationContract]
        ICollection<HotelRoomContract> HotelRoomGetAllWhereId(int? id);

        [OperationContract]
        HotelRoomContract HotelRoomGetWhereId(int? id);

        [OperationContract]
        void HotelRoomAdd(HotelRoomContract contract);

        [OperationContract]
        void HotelRoomEdit(HotelRoomContract contract);

        [OperationContract]
        void HotelRoomDelete(HotelRoomContract contract);




    }



}
