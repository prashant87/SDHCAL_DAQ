
 add_fsm_encoding \
       {usb_synchronous_slavefifo.State} \
       { }  \
       {{000 000} {001 001} {010 010} {011 011} {100 100} {101 101} }

 add_fsm_encoding \
       {Microroc_Parameters.State} \
       { }  \
       {{000 000} {001 001} {010 010} {011 011} {100 100} {101 101} {110 110} {111 111} }

 add_fsm_encoding \
       {Param_Bitshift.State} \
       { }  \
       {{000 000} {001 001} {010 011} {011 100} {100 110} {101 101} {110 010} }

 add_fsm_encoding \
       {AutoDaq.State} \
       { }  \
       {{0000 0000} {0001 0001} {0010 0010} {0011 0011} {0100 0100} {0101 0101} {0110 0110} {0111 0111} {1000 1000} }

 add_fsm_encoding \
       {SlaveDaq.State} \
       { }  \
       {{00000 00000} {00001 00001} {00010 00010} {00011 00011} {00100 00100} {00101 00110} {00110 00111} {00111 01000} {01000 01001} {01001 01010} {01010 01011} {01011 01100} {01100 00101} {01101 01101} {01110 01110} {01111 01111} {10000 10000} {10001 10001} {10010 10010} }

 add_fsm_encoding \
       {SweepACQ_Control.State} \
       { }  \
       {{0000 000000000000001} {0001 000000000000010} {0010 000000000001000} {0011 000000000000100} {0100 000000010000000} {0101 000000001000000} {0110 000000000010000} {0111 000000000100000} {1001 100000000000000} {1010 001000000000000} {1011 010000000000000} {1100 000000100000000} {1101 000001000000000} {1110 000100000000000} {1111 000010000000000} }

 add_fsm_encoding \
       {SCurve_Single_Test.TEST_State} \
       { }  \
       {{000 000} {001 001} {010 010} {011 011} {100 100} {101 101} {110 110} }

 add_fsm_encoding \
       {AdcControl.State} \
       { }  \
       {{000 000} {001 001} {010 010} {011 011} {100 100} }

 add_fsm_encoding \
       {TrigEfficiencyTest.TestState} \
       { }  \
       {{000 000} {001 001} {010 010} {011 011} {100 100} {101 101} {110 110} {111 111} }
