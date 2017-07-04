# 
# Synthesis run script generated by Vivado
# 

set_param xicom.use_bs_reader 1
set_param simulator.modelsimInstallPath D:/Program%20Files/ModelSim/win64
set_msg_config -id {HDL 9-1061} -limit 100000
set_msg_config -id {HDL 9-1654} -limit 100000
set_msg_config  -ruleid {1}  -id {Synth 8-3917}  -string {{WARNING: [Synth 8-3917] design FPGA_TOP has port usb_slcs driven by constant 0}}  -suppress 
set_msg_config  -ruleid {2}  -id {Synth 8-3917}  -string {{WARNING: [Synth 8-3917] design FPGA_TOP has port usb_fifoaddr[0] driven by constant 0}}  -suppress 
set_msg_config  -ruleid {3}  -id {Project 1-486}  -string {{WARNING: [Project 1-486] Could not resolve non-primitive black box cell 'usb_cmd_fifo' instantiated as 'usb_control/usbcmdfifo_16depth' [D:/Xilinx_Vivado_workspace/SDHCAL_DAQ2V0/RTL/usb_command_interpreter.v:55]}}  -suppress 
set_msg_config  -ruleid {4}  -id {Project 1-486}  -string {{WARNING: [Project 1-486] Could not resolve non-primitive black box cell 'usb_data_fifo' instantiated as 'usb_data_fifo_8192depth' [D:/Xilinx_Vivado_workspace/SDHCAL_DAQ2V0/RTL/FPGA_TOP.v:294]}}  -suppress 
set_msg_config  -ruleid {5}  -id {Project 1-486}  -string {{WARNING: [Project 1-486] Could not resolve non-primitive black box cell 'param_store_fifo' instantiated as 'Microroc_u1/SC_Readreg/param_store_fifo_16bitx256deep' [D:/Xilinx_Vivado_workspace/SDHCAL_DAQ2V0/RTL/SlowControl_ReadReg.v:339]}}  -suppress 
set_msg_config  -ruleid {6}  -id {Synth 8-3917}  -string {{WARNING: [Synth 8-3917] design FPGA_TOP has port LED[5] driven by constant 1}}  -suppress 
set_msg_config  -ruleid {7}  -id {Synth 8-350}  -string {{WARNING: [Synth 8-350] instance 'SC_Readreg' of module 'SlowControl_ReadReg' requires 53 connections, but only 52 given [D:/Xilinx_Vivado_workspace/SDHCAL_DAQ2V0/RTL/Microroc_top.v:135]}}  -suppress 
set_msg_config  -ruleid {8}  -id {Project 1-486}  -string {{WARNING: [Project 1-486] Could not resolve non-primitive black box cell 'param_store_fifo' instantiated as 'Microroc_u1/SC_Readreg/param_store_fifo_16bitx256deep' [D:/Xilinx_Vivado_workspace/SDHCAL_DAQ2V0/RTL/SlowControl_ReadReg.v:283]}}  -suppress 
create_project -in_memory -part xc7a100tfgg484-2

set_param project.singleFileAddWarning.threshold 0
set_param project.compositeFile.enableAutoGeneration 0
set_param synth.vivado.isSynthRun true
set_msg_config -source 4 -id {IP_Flow 19-2162} -severity warning -new_severity info
set_property webtalk.parent_dir D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.cache/wt [current_project]
set_property parent.project_path D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.xpr [current_project]
set_property XPM_LIBRARIES {XPM_CDC XPM_MEMORY} [current_project]
set_property default_lib xil_defaultlib [current_project]
set_property target_language Verilog [current_project]
set_property ip_output_repo d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.cache/ip [current_project]
set_property ip_cache_permissions {read write} [current_project]
add_files -quiet d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/param_store_fifo/param_store_fifo.dcp
set_property used_in_implementation false [get_files d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/param_store_fifo/param_store_fifo.dcp]
add_files -quiet d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_cmd_fifo/usb_cmd_fifo.dcp
set_property used_in_implementation false [get_files d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_cmd_fifo/usb_cmd_fifo.dcp]
read_verilog -library xil_defaultlib {
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SCurve_Single_Input.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SlaveDaq.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/PULSESYNC.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Param_Bitshift.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Microroc_Parameters.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/DaqSwitcher.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/AutoDaq.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/ADC_AD9220.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SweepACQ_Control.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SCurve_Test_Control.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SCurve_Single_Test.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Trig_Gen.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SlowControl_ReadReg.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Redundancy.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/RazGen.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/RamReadOut.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Internal_Trig_Gen.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/HoldGen.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/DaqControl.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/AdcControl.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Switcher.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SweepACQ_Top.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/SCurve_Test_Top.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/usb_command_interpreter.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Microroc_top.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/TrigCoincid.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Controller_Top.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/usb_synchronous_slavefifo.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/Clk_Management.v
  D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/RTL/FPGA_TOP.v
}
read_ip -quiet D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SweepACQ_FIFO/SweepACQ_FIFO.xci
set_property used_in_implementation false [get_files -all d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SweepACQ_FIFO/SweepACQ_FIFO/SweepACQ_FIFO.xdc]
set_property is_locked true [get_files D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SweepACQ_FIFO/SweepACQ_FIFO.xci]

read_ip -quiet D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SCurve_Data_FIFO/SCurve_Data_FIFO.xci
set_property used_in_implementation false [get_files -all d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SCurve_Data_FIFO/SCurve_Data_FIFO/SCurve_Data_FIFO.xdc]
set_property used_in_implementation false [get_files -all d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SCurve_Data_FIFO/SCurve_Data_FIFO_ooc.xdc]
set_property is_locked true [get_files D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/SCurve_Data_FIFO/SCurve_Data_FIFO.xci]

read_ip -quiet D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_data_fifo/usb_data_fifo.xci
set_property used_in_implementation false [get_files -all d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_data_fifo/usb_data_fifo/usb_data_fifo.xdc]
set_property used_in_implementation false [get_files -all d:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_data_fifo/usb_data_fifo/usb_data_fifo_clocks.xdc]
set_property is_locked true [get_files D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/SDHCAL_DAQ2V0.srcs/sources_1/ip/usb_data_fifo/usb_data_fifo.xci]

foreach dcp [get_files -quiet -all *.dcp] {
  set_property used_in_implementation false $dcp
}
read_xdc D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/Constraints/SDHCAL_DAQ2V0.xdc
set_property used_in_implementation false [get_files D:/MyProject/SDHCAL_DAQ/SDHCAL_DAQ2V0_SCurveTest/Constraints/SDHCAL_DAQ2V0.xdc]

read_xdc dont_touch.xdc
set_property used_in_implementation false [get_files dont_touch.xdc]

synth_design -top FPGA_TOP -part xc7a100tfgg484-2


write_checkpoint -force -noxdef FPGA_TOP.dcp

catch { report_utilization -file FPGA_TOP_utilization_synth.rpt -pb FPGA_TOP_utilization_synth.pb }
