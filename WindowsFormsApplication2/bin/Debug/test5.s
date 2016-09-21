main:
	lda #$3
	sta $1
	
	lda #$0
	sta $2

loop:
	lda #$2
	sta $3
	
	lda $1
	div $3
	sta $2
	
	lda $3
	add $1
	sta $3
	
	lda $2
	sub #$9
	be if
	lda $1
	sub #$1
	sta $1
	ba loop
if:
	lda #$255
	add #$1
	mul $3
	sta $4
	
	lda #$255
	add #$2
	mul $1
	
	add $4
	sta $2

rehash:
	and $1
	sta $4
	lda $2
	or $1
	and $2
	sta $2
out:
	lda $2