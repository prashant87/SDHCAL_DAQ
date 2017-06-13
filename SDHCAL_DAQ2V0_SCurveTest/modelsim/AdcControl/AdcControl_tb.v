`timescale 1ns / 1ns
module AdcControl_tb;
  reg Clk;
  reg reset_n;
  reg Hold;
  reg StartAcq;
  reg [3:0] AdcStartDelay;
  reg [11:0] ADC_DATA;
  reg ADC_OTR;
  wire ADC_CLK;
  wire [15:0] SumData;
  wire SumData_en;
  AdcControl uut(
    .Clk(Clk),
    .reset_n(reset_n),
    .Hold(Hold),
    .StartAcq(StartAcq),
    .AdcStartDelay(AdcStartDelay),
    .ADC_DATA(ADC_DATA),
    .ADC_OTR(ADC_OTR),
    .ADC_CLK(ADC_CLK),
    .SumData(SumData),
    .SumData_en(SumData_en)
  );
  // ***initial
  initial begin
    Clk = 1'b0;
    reset_n = 1'b0;
    Hold = 1'b0;
    StartAcq = 1'b0;
    AdcStartDelay = 4'd10;
    ADC_OTR = 1'b0;
    #100;
    reset_n = 1'b1;
    #100;
    StartAcq = 1'b1;
    #100;
    Hold = 1'b1;
  end
  // Generate ADC Data
  always @(posedge ADC_CLK or negedge reset_n) begin
    if(~reset_n)
      ADC_DATA <= 12'b0;
    else begin
      #(8); ADC_DATA <= ADC_DATA + 1'b1;
    end
  end
  // Generate Clk
  localparam HighTime = 13;
  localparam LowTime = 12;
  always begin
    #(LowTime) Clk = ~Clk;
    #(HighTime) Clk = ~Clk;
  end
endmodule
