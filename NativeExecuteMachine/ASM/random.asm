__start:
    rand 100, 110
    out rnd, 1
    add r1, 1
    cmp r1, 1000
    ife, go __stop
    go __start

__stop:
    clear registres