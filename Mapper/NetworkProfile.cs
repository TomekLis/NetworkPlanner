using AutoMapper;
using NetworkPlanner.Model;
using NetworkPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkPlanner.Mapper
{
    public class NetworkProfile : Profile
    {
        public NetworkProfile()
        {
            CreateMap<PlanViewModel, Plan>();
            CreateMap<CellViewModel, Cell>();
            CreateMap<GridViewModel, Grid>();
            CreateMap<LatLngViewModel, LatLng>();
            CreateMap<PlanForListViewModel, Plan>();
            CreateMap<VertexViewModel, Vertex>();
        }
    }
}
