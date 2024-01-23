using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;

public class BaseBillModel
{
    public string? Title { get; set; }
    public int ContractId { get; set; }
    public string? HostName { get; set; }
    public string? HostPhone { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerPhone { get; set; }
    public DateTime? RoomFromDate { get; set; }
    public DateTime? RoomToDate { get; set; }
    public DateTime? ElectricFromDate { get; set; }
    public DateTime? ElectricToDate { get; set; }
    public double? ElectricLastMonth { get; set; }
    public double? ElectricThisMonth { get; set; }
    public double? ElectricValue { get; set; }
    public double? ElectricPrice { get; set; }
    public double? ElectricTotal { get; set; }
    public DateTime? WaterFromDate { get; set; }
    public DateTime? WaterToDate { get; set; }
    public double? WaterLastMonth { get; set; }
    public double? WaterThisMonth { get; set; }
    public double? WaterValue { get; set; }
    public double? WaterPrice { get; set; }
    public double? WaterTotal { get; set; }
    public double? Oweing { get; set; }

    public BaseContractModel? Contract { get; set; }
}
