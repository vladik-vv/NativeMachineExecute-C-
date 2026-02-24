__start:
    go main
    hlt
.e

.p stop:
    out "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", 1
    out "!!!!!!!!ЕСЛИ ВИДЕТЕ ЭТОТ ТЕКСТ, ТО ИНТЕРПРЕТАТОР РАБОТАЕТ НЕ КОРРЕКТНО!!!!!!!!!", 1
    out "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", 1
    hlt
.e

.p next:
    mov bytes,      50
    mov shorts,     500
    mov floats,     5000
    mov doubles,    50000
    mov text,       ":text_dump:"
    mov bytesARR[44],  100
    mov shortsARR[44],  1000
    mov floatsARR[44],  10000
    mov doublesARR[44],  100000
    mov textARR[44], "-text_arr-"

    cmp r4, 100
    ife, go stop

    mov player.x,   100
    mov player.y,   200
    mov cube.x,     300
    mov cube.y,     400
    mov cube.z,     500
    mov space.x,    600
    mov space.y,    700
    mov space.z,    800
    mov space.w,    900

    add player.x,   1
    add player.y,   1
    add cube.x,     1
    add cube.y,     1
    add cube.z,     1
    add space.x,    1
    add space.y,    1
    add space.z,    1
    add space.w,    1

    sub player.x,   2
    sub player.y,   2
    sub cube.x,     2
    sub cube.y,     2
    sub cube.z,     2
    sub space.x,    2
    sub space.y,    2
    sub space.z,    2
    sub space.w,    2

    cmp r5, 500
    ife, go stop

    mul player.x,   2
    mul player.y,   2
    mul cube.x,     2
    mul cube.y,     2
    mul cube.z,     2
    mul space.x,    2
    mul space.y,    2
    mul space.z,    2
    mul space.w,    2
    
    div player.x,   4
    div player.y,   4
    div cube.x,     4
    div cube.y,     4
    div cube.z,     4
    div space.x,    4
    div space.y,    4
    div space.z,    4
    div space.w,    4

    cmp r5, 500
    ifh, go stop

    add bytes,          bytes 
    add shorts,         shorts
    add floats,         floats
    add doubles,        doubles
    add text,           text    
    add bytesARR[44],   bytesARR[44]
    add shortsARR[44],  shortsARR[44]
    add floatsARR[44],  floatsARR[44]
    add doublesARR[44], doublesARR[44]
    add textARR[44],    textARR[44]

    mul bytes,          r1
    mul shorts,         r1
    mul floats,         r1
    mul doubles,        r1
    mul bytesARR[44],   r1
    mul shortsARR[44],  r1
    mul floatsARR[44],  r1
    mul doublesARR[44], r1

    cmp r4, r5
    ifl, go stop


    div bytes,          r2
    div shorts,         r2
    div floats,         r2
    div doubles,        r2
    div bytesARR[44],   r2
    div shortsARR[44],  r2
    div floatsARR[44],  r2
    div doublesARR[44], r2

    sub bytes,          r3
    sub shorts,         r3
    sub floats,         r3
    sub doubles,        r3
    sub bytesARR[44],   r3
    sub shortsARR[44],  r3
    sub floatsARR[44],  r3
    sub doublesARR[44], r3
    
    out "", 2
    out "196   = ",     0
    out bytes,          1
    out "300   = ",     0
    out shorts,         1
    out "3900  = ",     0
    out floats,         1
    out "39900 = ",     0
    out doubles,        1
    out ":text_dump::text_dump: = ", 0
    out text,           1
    out "элемент номер 1 текста свыше = ", 0
    out text[1], 2
    out "184   = ",     0
    out bytesARR[44],   1
    out "700   = ",     0
    out shortsARR[44],  1
    out "7900  = ",     0
    out floatsARR[44],  1
    out "79900 = ",     0
    out doublesARR[44], 1
    out "-text_arr--text_arr-  = ",     0
    out textARR[44],    1
    vec2, playerT
    mov r5, 15
    db num, 30
    mov playerT.x, 45
    arrb arbytes, 100

    mov arbytes[15], 99
    mov arbytes[30], 188
    mov arbytes[45], 222
    mov arbytes[60], 244

    out "99    = ", 0
    out arbytes[r5], 1
    out "188   = ", 0
    out arbytes[num], 1
    out "222   = ", 0
    out arbytes[playerT.x], 1
    out "244   = ", 0
    out arbytes[60], 1
    add arbytes[r5], arbytes[r5]
    out "198   = ", 0
    out arbytes[r5], 1

    out "----------------------------------------", 2

    out "player: x48.5 y100.5 | cube: x148.5 y200.5 z249.5 | space: x298.5 y350.5 z399.5 w449.5", 2
    out "Vector2 player = ", 0
    out player,     1
    out "Vector3 cube   = ", 0
    out cube,       1
    out "Vector4 space  = ", 0
    out space,      2

    add player.x, player.x
    add player.y, player.y
    add cube.x, cube.x
    add cube.y, cube.y
    add cube.z, cube.z
    add space.x, space.x
    add space.y, space.y
    add space.z, space.z
    add space.w, space.w

    out "Координаты в ручную + x2", 2
    out "Vector2 player     = ", 0
    out "X:",                0
    out player.x,            0  
    out " Y:",               0
    out player.y,            1
    out "Vector3 cube       = ", 0
    out "X:",                0
    out cube.x,              0
    out " Y:",               0
    out cube.y,              0
    out " Z:",               0
    out cube.z,              1
    out "Vector4 cube       = ", 0
    out "X:",                0
    out space.x,             0
    out " Y:",               0
    out space.y,             0
    out " Z:",               0
    out space.z,             0
    out " W:",               0
    out space.w,             2
    vec2, p1
    vec2, p2

    vec3, c1
    vec3, c2

    vec4, s1
    vec4, s2

    mov p1.x, 20
    mov p1.y, 40
    mov p2.x, 90
    mov p2.y, 45
    mov c1.x, 20
    mov c1.y, 40
    mov c1.z, 100
    mov c2.x, 90
    mov c2.y, 45
    mov c2.z, -100
    mov s1.x, 20
    mov s1.y, 40
    mov s1.z, 100
    mov s1.w, 900
    mov s2.x, 90
    mov s2.y, 45
    mov s2.z, -100
    mov s2.w, 200

    dst p1, p2
    out "70.178344238091    = ", 0
    out rvc, 1

    dst c1, c2
    out "211.95518394226644 = ", 0
    out rvc, 1

    dst s1, s2
    out "731.3856711749281  = ", 0
    out rvc, 1

    vec2, label
    vec3, circle
    vec4, 3dobj

    mov label.x, 15
    mov label.y, 30

    mov circle.x, 15
    mov circle.y, 30
    mov circle.z, 45

    mov 3dobj.x, 15
    mov 3dobj.y, 30
    mov 3dobj.z, 45
    mov 3dobj.w, 60

    lng r1, label
    out "33.54101966249684  = ", 0
    out r1, 1
    lng r1, circle
    out "56.124860801609124 = ", 0
    out r1, 1 
    lng r1, 3dobj
    out "82.15838362577492  = ", 0
    out r1, 1
    lngsq r1, 3dobj
    out "6750 = ", 0
    out r1, 1
    out "Текущая нажатая клавиша: ", 0
    out keyboard.key, 1

    out "----------------------------------------", 2
    
    out r1,                0
    out " & 120       = ", 0
    cmp r1,              120
    tst_cmp_
    out r2,                0
    out " &   ",           0
    out r1,                0
    out "       = ",       0
    cmp r2, r1
    tst_cmp_
    cmp doubles, doubles
    out doubles,           0
    out " & ",             0
    out doubles,           0
    out " = ",             0
    tst_cmp_
    out "",                1
    cmp text, text
    out text,              0
    out " & ",             0
    out text,              0
    out " = ",             0
    tst_cmp_
    cmp text, doubles
    out text,              0
    out " & ",             0
    out doubles,           0
    out "                  = ", 0
    tst_cmp_
    cmp text,              5
    out text,              0 
    out " & ",             0
    out 5,                 0
    out "                      = ", 0
    tst_cmp_
    out "",                1
    rand -100000, 100000
    out "рандомное значение от -100000 до 100000 = ", 0
    out rnd, 1
    mov r1, 9856
    mov r2, 985
    out "остаток от деления ", 0
    out r1, 0
    out " и ", 0
    out r2, 0
    out " = ", 0
    div r1, r2
    out rnr, 2
    mov r2, 5000

    cos r1, r2
    out "Косинус 5000 = ", 0
    out r1, 1

    sin r1, r2
    out "Синус   5000 = ", 0
    out r1, 1

    tan r1, r2
    out "Тангенс 5000 = ", 0
    out r1, 1

    arrb numbers, 10
    mov numbers[0], 10
    mov numbers[1], 1
    mov numbers[2], 10
    mov numbers[3], 8
    mov numbers[4], 10
    mov numbers[5], 20
    mov numbers[6], 10
    mov numbers[7], 15
    mov numbers[8], 10
    mov numbers[9], 10

    max r1, numbers
    out "максимальный элемент (10, 1, 10, 8, 10, 20, 10, 15, 10, 10) = ", 0
    out r1, 1
    min r1, numbers
    out "минимальный элемент (10, 1, 10, 8, 10, 20, 10, 15, 10, 10) = ", 0
    out r1, 1

    ds textus, "Four"
    len r1, textus

    out "Длина текста ", 0
    out textus, 0
    out ": ", 0
    out r1, 1
    arrb tempnumbs, 10
    mov tempnumbs[0], 4
    mov tempnumbs[1], 2
    mov tempnumbs[2], 7
    mov tempnumbs[3], 6
    mov tempnumbs[4], 5
    mov tempnumbs[5], 4
    mov tempnumbs[6], 3
    srt tempnumbs
    out "6 = ", 0
    out tempnumbs[8], 2

    out "----------------------------------------", 2
    out "ВЫВОД:", 1
    out "Состояние регистров перед очисткой: ", 0
    out r1, 0
    out " ", 0
    out r2, 0
    out " ", 0
    out r3, 0
    out " ", 0
    out r4, 0
    out " ", 0
    out r5, 0
    out " ", 0
    out rnd, 0
    out " ", 0
    out rnr, 0
    out " ", 0
    out rvc, 0
    out "", 1
    out "Имена занятых адресов перед очисткой: ", 0
    tst_vars_
    clear bytes
    clear shorts
    clear floats
    clear doubles
    clear text
    clear player
    clear cube
    clear space
    clear registres
    clear bytesARR
    clear shortsARR
    clear floatsARR
    clear doublesARR
    clear textARR
    clear playerT
    clear num
    clear arbytes
    clear p1
    clear p2
    clear c1
    clear c2
    clear s1
    clear s2
    clear label
    clear circle
    clear 3dobj
    clear numbers
    clear textus
    clear tempnumbs
    out "", 2
    out "Состояние регистров после очистки: ", 0
    out r1, 0
    out " ", 0
    out r2, 0
    out " ", 0
    out r3, 0
    out " ", 0
    out r4, 0
    out " ", 0
    out r5, 0
    out " ", 0
    out rnd, 0
    out " ", 0
    out rnr, 0
    out " ", 0
    out rvc, 0
    out "", 1
    out "Имена занятых адресов после очистки: ", 0
    tst_vars_
    out "", 1
    ret
.e


.p cls:
    clear screen
    ret
.e


.p main:
    out "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", 1
    out "!!!!!!!!ЕСЛИ ВИДЕТЕ ЭТОТ ТЕКСТ, ТО ИНТЕРПРЕТАТОР РАБОТАЕТ НЕ КОРРЕКТНО!!!!!!!!!", 1
    out "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", 1
    call cls
    call cls
    out "Состояние регистров в начале: ", 0
    out r1, 0
    out " ", 0
    out r2, 0
    out " ", 0
    out r3, 0
    out " ", 0
    out r4, 0
    out " ", 0
    out r5, 0
    out " ", 0
    out rnd, 0
    out " ", 0
    out rnr, 0
    out " ", 0
    out rvc, 0

    mov r1,         2
    mov r2,         5
    mov r3,         100
    mov r4,         500
    mov r5,         200
    db bytes,       0
    dw shorts,      0
    dd floats,      0
    dq doubles,     0
    ds text,        ""
    arrb bytesARR, 100
    arrw shortsARR, 100
    arrd floatsARR, 100
    arrq doublesARR, 100
    arrs textARR, 100
    vec2,           player
    vec3,           cube
    vec4,           space

    cmp bytesARR[50], bytesARR[50]
    ifn, go stop

    go next
.e


__stop:
    out "Конец кода, блок: СТОП", 1
    out "Ошибок интерпретатора: 0", 2
    clear keyboard.key
.e
