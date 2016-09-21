! Self Test
main:
	lda #$1 	! ACC = 1
	sta $1		! Store 1 to reg[1]
	add #$2		! ACC = 3
	add $1		! ACC = 4
	div #$2     ! ACC = 2
	sta $2      ! Store 2 to reg[2]
	div $2      ! ACC = 1
	and #$0     ! ACC = 0
	or #$1   	! ACC = 1
	and $1		! ACC = 1
	or $2		! ACC = 3
	sub #$3		! ACC = 0
	be b1		! branch to b1
	hlt			! fail

b1:
	add $1		! ACC = 1
	bg b2       ! branch to b2
	hlt			! fail
	
b2:
	sub #$2		! ACC = -1
	bl b3		! branch to b3
	hlt			! fail

b3:
	ba b4		! branch to b4
	hlt			! fail
	
b4:
	nop			! Do nothing
	nota		! I have no idea what this will do