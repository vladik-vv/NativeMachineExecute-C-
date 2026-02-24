__start:
    out "made by arslan", 2
    out "Введите размер поля(0 - выход из игры): ", 0

    db event, 0
    inp r1
    cmp r1, 0
    ife go __stop

    db size, r1
    arrb arr, size

    mov r2, 0
    call create

    go main

.p main:
    mov r2, 0
    call print_arr

    out "Введите номер числа(не индекс, 0 - выход из игры): ", 0
    inp r1

    cmp r1, 0
    ife go __stop

    mov event, r1

    cmp event, 1
    ife go begin

    cmp event, size
    ife go ending

    go norm

.p begin:
    mov r1, 0
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    mov r1, 1
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    mov r2, 0
    go game_end

.p ending:
    mov r1, size
    sub r1, 1
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    sub r1, 1
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    mov r2, 0
    go game_end

.p norm:
    mov r1, event
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    sub r1, 1
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    sub r1, 1
    cmp arr[r1], 0
    ife call inp_one
    ifn call inp_zero

    mov r2, 0
    go game_end

.p inp_one:
    mov arr[r1], 1
    ret

.p inp_zero:
    mov arr[r1], 0
    ret

.p create:
    mov arr[r2], 0

    add r2, 1

    cmp r2, size
    ifn go create

    ret

.p print_arr:
    out arr[r2], 0

    add r2, 1

    cmp r2, size
    ifn go print_arr

    out "", 1

    ret

.p game_end:
    cmp arr[r2], 0
    ife go main

    add r2, 1

    cmp r2, size
    ifn go game_end

    mov r2, 0
    call print_arr
    out "Ты выйграл!", 1

__stop:
    clear registres
    clear arr
    clear size
    clear event
