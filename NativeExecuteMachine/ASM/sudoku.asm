__start:
    mx2_q board, 9*9
    mx2_q copyBoard, 9*9
    arrb number, 9
    ds p_cursor, "X"
    db hp, 5
    db playerY, 5
    db playerX, 5
    db isRunning, 1

    db convert, 0
    db bigRow, 0
    db bigCol, 0

    db checkRow, 0
    db checkCol, 0

    db temp, 0

    db num, 0

    db row, 0
    db col, 0

    db newRow, 0
    db newCol, 0

    db rndNum, 0
    db rndRow, 0
    db rndCol, 0

    db myCheckResult, 0

    db randSudokuResult, 0

    db i, 0
    db j, 0
    db e, 0
    go drawboard

.p return:
    ret

.p myCheck:
    mov i, 0

    .p myCheckCol:
        mov r3, num
        cmp r3, board[i*col]
        mov myCheckResult, 0
        ife go return

        add i, 1
        cmp i, 9
        ifn go myCheckCol

        mov i, 0

    .p myCheckRow:
        mov r3, num
        cmp r3, board[row*i]
        mov myCheckResult, 0
        ife go return

        add i, 1
        cmp i, 9
        ifn go myCheckRow

        mov convert, row
        div convert, 3
        mul convert, 3
        mov bigRow, convert

        mov convert, col
        div convert, 3
        mul convert, 3
        mov bigCol, convert

        mov i, 0

    .p blockRow:
        mov j, 0

    .p blockCol:
        mov r1, bigRow
        add r1, i
        mov checkRow, r1

        mov r1, bigCol
        add r1, j
        mov checkCol, r1

        cmp checkRow, row
        ifn go checkBlockCell
        cmp checkCol, col
        ifn go checkBlockCell

        go nextBlockCell

    .p checkBlockCell:
        cmp board[checkRow*checkCol], num
        mov myCheckResult, 0
        ife go return

    .p nextBlockCell:
        add j, 1
        cmp j, 3
        ifn go blockCol

        add i, 1
        cmp i, 3
        ifn go blockRow

        mov myCheckResult, 1
        ret

.p randSudoku:
    pusha

    cmp row, 9
    ifn go continueRand
    mov randSudokuResult, 1
    go restoreRand

    .p continueRand:
        mov newRow, row
        mov r1, col
        add r1, 1
        mov newCol, r1

        cmp newCol, 9
        ifn go checkBoardCell
        add newRow, 1
        mov newCol, 0

    .p checkBoardCell:
        mov r3, 0 
        cmp r3, board[row*col]
        ife go tryNumber

        mov r1, row
        mov r2, col
        mov r3, newRow
        mov r4, newCol

        mov row, r3
        mov col, r4

        call randSudoku

        mov row, r1
        mov col, r2

        go restoreRand

    .p tryNumber:
        mov number[0], 1
        mov number[1], 2
        mov number[2], 3
        mov number[3], 4
        mov number[4], 5
        mov number[5], 6
        mov number[6], 7
        mov number[7], 8
        mov number[8], 9

        rss number

        mov i, 0

    .p nextNumber:
        cmp i, 9
        ife go allFailed

        mov num, number[i]

        mov r1, i
        push r1
        call myCheck
        pop r1
        mov i, r1

        cmp myCheckResult, 1
        ifn go tryNext

        mov board[row*col], num

        mov r1, row
        mov r2, col
        mov r3, newRow
        mov r4, newCol
        mov r5, i
        mov rnr, num
        pusha

        mov row, newRow
        mov col, newCol
        call randSudoku

        popa
        mov row, r1
        mov col, r2
        mov newRow, r3
        mov newCol, r4
        mov i, r5
        mov num, rnr

        cmp randSudokuResult, 1
        ife go success

        mov board[row*col], 0

    .p tryNext:
        add i, 1
        go nextNumber

    .p allFailed:
        mov randSudokuResult, 0
        go restoreRand

    .p success:
        mov randSudokuResult, 1

    .p restoreRand:
        popa
        ret

.p printPlayer:
    cmp row, playerX
    ifn go printNumber

    cmp col, playerY
    ifn go printNumber

    out p_cursor, 0
    go printSeparator

    .p printNumber:
        mov r3, board[row*col]
        ;cmp r3, 0
        ;ife go printSpace0

        out board[row*col], 0
        go printSeparator

    ;.p printSpace0:
       ; out " ", 0

    .p printSeparator:
        mov r1, col
        add r1, 1
        div r1, 3

        cmp rnr, 0
        ifn go printSpace1

        cmp col, 8
        ife go printSpace1

        out "|", 0
        go continueCol

    .p printSpace1:
        out " ", 0

    .p continueCol:
        add col, 1
        cmp col, 9
        ifn go printPlayer

        out "", 1

        mov r1, row
        add r1, 1
        div r1, 3

        cmp rnr, 0
        ifn go continueRow

        cmp row, 8
        ife go continueRow

        mov e, 0

    .p printLine:
        mov r1, e
        add r1, 1
        div r1, 6

        cmp rnr, 0
        ifn go printDash

        cmp e, 17
        ife go printDash

        out "+", 0
        go continueLine

    .p printDash:
        out "-", 0

    .p continueLine:
        add e, 1
        cmp e, 18
        ifn go printLine

        out "", 1

    .p continueRow:
    add row, 1
    cmp row, 9
    mov col, 0
    ifn go printPlayer

    ret

.p drawboard:
    push r1
    push r2
    push r3

    mov i, 0

    .p clear1Row:
        mov j, 0
    
    .p clear1Col:
        mov board[i*j], 0

        add j, 1
        cmp j, 9
        ifn go clear1Col

        add i, 1
        cmp i, 9
        ifn go clear1Row

        mov row, 0
        mov col, 0
        call randSudoku

        out board, 1*1
        mov i, 0

    .p copyRow:
        mov j, 0

    .p copyCol:
        mov r2, board[i*j]
        mov copyBoard[i*j], r2

        add j, 1
        cmp j, 9
        ifn go copyCol

        add i, 1
        cmp i, 9
        ifn go copyRow

        mov i, 0
    
    .p clear2Row:
        mov j, 0

    .p clear2Col:
        mov board[i*j], 0

        add j, 1
        cmp j, 9
        ifn go clear2Col

        add i, 1
        cmp i, 9
        ifn go clear2Row

        rand 100, 110

        mov rndNum, rnd
        out rndNum, 1

        mov i, 0

    .p fillLoop:
        cmp i, rndNum
        ife go drawboardEnd

        rand 0, 9
        mov rndRow, rnd
        rand 0, 9
        mov rndCol, rnd

        mov board[rndRow*rndCol], copyBoard[rndRow*rndCol]

        add i, 1
        go fillLoop

    .p drawboardEnd:
        popa
        go run

.p run:
    mov row, 0
    mov col, 0
    call printPlayer

    out "У вас ", 0
    out hp, 0
    out " жизней", 1

__stop:
    clear registres
    clear board
    clear copyBoard
    clear p_cursor
    clear hp
    clear playerX
    clear playerY
    clear isRunning
    clear row
    clear col
    clear i
    clear j
    clear e
    clear convert
    clear bigRow
    clear bigCol
    clear temp
    clear num
    clear myCheckResult
    clear randSudokuResult
    clear newRow
    clear newCol
    clear number
    clear rndNum
    clear rndRow
    clear rndCol