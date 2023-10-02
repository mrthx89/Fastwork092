using AutoMapper;
using EM4.App.Model.Entity;
using EM4.App.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Utils
{
    public class AutoMapperConfig
    {
        public IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TInventor, ItemMaster>();
                cfg.CreateMap<ItemMaster, TInventor>();
                
                cfg.CreateMap<TStockIn, StokMasuk>();
                cfg.CreateMap<StokMasuk, TStockIn>();
                cfg.CreateMap<TStockCard, StokMasuk>();
                cfg.CreateMap<StokMasuk, TStockCard>();

                cfg.CreateMap<TStockOut, StokKeluar>();
                cfg.CreateMap<StokKeluar, TStockOut>();
                cfg.CreateMap<TStockCard, StokKeluar>();
                cfg.CreateMap<StokKeluar, TStockCard>();

                cfg.CreateMap<TStockPengembalian, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, TStockPengembalian>();
                cfg.CreateMap<TStockCard, StokPengembalian>();
                cfg.CreateMap<StokPengembalian, TStockCard>();
            });

            return config.CreateMapper();
        }
    }
}
