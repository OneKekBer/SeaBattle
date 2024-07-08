import { IBoard } from '../interfaces/IBoard'

// helpers/Converter.ts
export function convertStringToArray(boardData: IBoard): string[][] {
	const { board } = boardData
	const length = 9

	// Log the input data for debugging
	console.log('Board Data:', boardData)

	const boardArray = board.split(' ')

	const twoDimensionalBoard: string[][] = []

	for (let i = 0; i < length; i++) {
		const row = boardArray.slice(i * length, (i + 1) * length)
		twoDimensionalBoard.push(row)
	}

	return twoDimensionalBoard
}
