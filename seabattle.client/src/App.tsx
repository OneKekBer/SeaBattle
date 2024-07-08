import React, { useState } from 'react'

type BoardType = string[][]

const initializeBoard = (rows: number, columns: number): BoardType => {
	return Array.from({ length: rows }, () => Array(columns).fill('1'))
}

const HandlePlateClick = (cellIndex: number, rowIndex: number) => {
	console.log(`${cellIndex + 1} ${rowIndex + 1}`)
}

const YourComponent = () => {
	const [board, setBoard] = useState<BoardType>(initializeBoard(9, 9)) // Initializing a 9x9 board with '1'

	// Rest of your component logic

	return (
		<div className='flex justify-center items-center w-screen'>
			<div>
				{board.map((row, rowIndex) => (
					<div key={rowIndex} className='flex'>
						{row.map((cell, cellIndex) => (
							<span
								className='w-[60px] h-[60px] bg-slate-200 text-black flex items-center justify-center border border-gray-300'
								key={cellIndex}
								onClick={() => HandlePlateClick(cellIndex, rowIndex)}
							>
								{cell}
							</span>
						))}
					</div>
				))}
			</div>
		</div>
	)
}

export default YourComponent
