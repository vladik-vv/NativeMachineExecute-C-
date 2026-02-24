__start:
    clear screen
    mx2_s map, 31*31
    vec2, player
    mov player.x, 5
    mov player.y, 10
    dq X, player.x
    dq Y, player.y
    dq lpx, 5
    dq lpy, 10
    dq llpx, 4
    dq llpy, 9

    mov r1, 0
    mov r2, 0
    .p fill_map:
        mov map[r1*r2], *
        add r2, 1

        cmp r2, 31
        ife, call next_fill_map

        go fill_map

    .p next_fill_map:
        cmp r1, 30
        ife, go process

        mov r2, 0
        add r1, 1
        ret


.p process:
    wait 50

    mov X, player.x 
    mov Y, player.y

    cmp keyboard.key, W
    ife, call move_up

    cmp keyboard.key, S 
    ife, call move_down

    cmp keyboard.key, A 
    ife, call move_left 

    cmp keyboard.key, D 
    ife, call move_right

    cmp keyboard.key, Q 
    ife, go __stop

    go process

    .p move_up:
        wait 25
        sub player.y, 1
        cmp Y, 0
        ife, go reverse_y_up
        go show_map

    .p move_down:
        wait 25
        add player.y, 1
        cmp Y, 30
        ife, go reverse_y_down
        go show_map

    .p move_right:
        add player.x, 1
        cmp X, 30
        ife, go reverse_x_right
        go show_map

    .p move_left:
        sub player.x, 1
        cmp X, 0
        ife, go reverse_x_left
        go show_map


    .p show_map:
        mov map[player.y*player.x], x
        mov map[lpy*lpx], .
        mov map[llpy*llpx], "*"
        mov llpx, lpx
        mov llpy, lpy
        mov lpx, player.x
        mov lpy, player.y

        clear cursor
        out map, 1*0
        
        out "позиция мышки: ", 0
        out player, 1

        ret

    .p reverse_x_right:

        mov player.x, 0
        mov X, 0

        go show_map


    .p reverse_x_left:

        mov player.x, 30
        mov X, 30

        go show_map


    .p reverse_y_up:

        mov player.y, 30
        mov Y, 30

        go show_map


    .p reverse_y_down:

        mov player.y, 0
        mov Y, 0

        go show_map


__stop:
    clear registres
    clear map
    clear player
    clear keyboard.key 
    clear lpx
    clear lpy
    clear llpx
    clear llpy
    clear X 
    clear Y 