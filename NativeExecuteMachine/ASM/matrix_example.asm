__start:
    mx2_s map, 10*10
    mx2_q doubles, 10*10

    mov doubles[2*2], 10
    out doubles, 1*1

    rss doubles

    out map, 1*0
    out doubles, 1*1
    ; первое число - количество отступов между строками
    ; второе число - количество пробелов между символами