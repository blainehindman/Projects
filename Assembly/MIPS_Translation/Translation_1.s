       #  MIPS Code
       #  This mini-program is just for you to get familiar with 
       #  MIPS and QtSPIM.
       
       .text
#Student ID: 11526888, last 2 "88"
main:  li $a0, 8 			# initialize argument 0, 8
       li $a1, 8 			# initialize argument 1, 8
       					# Register convention 
sum: 	  beq $a0, $zero, sum_ext # compare argument $a0 = 0
       add $a1, $a1, $a0 		# add arguments
       addi $a0, $a0, -1		# a0 - 1
       j sum 				# unconditional jump to sum

sum_ext: li $v0, 4 			# syscall code for print_string
  la $a0, str 				# argument for system call
       syscall				# Read system calls (page A-44)
       move $a0, $a1 			# argument for system call
       li $v0, 1 			# syscall code for print_integer
       syscall

       li	$v0,10			# exit
		syscall


       .data
str:	 .asciiz "the sum is: "

