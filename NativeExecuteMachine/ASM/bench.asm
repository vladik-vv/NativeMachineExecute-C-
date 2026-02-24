__start:
    mov r1, 1000
    div r1, 5
    mul r1, 5
    sub r1, 900
    add r1, 900
    mul r1, r1
    mul r1, r1
    add r2, 1
    cmp r2, 3000
    ife, go __stop
    go __start

__stop:
    out r1, 1
    