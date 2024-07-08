import { useAppDispatch, useAppSelector } from './state/hooks'
import { fetchBoard } from './state/boardSlice'
import { useEffect } from 'react'

const App = () => {
	const board = useAppSelector(store => store.board.board)
	const dispatch = useAppDispatch()

	const HandleStart = () => {
		dispatch(fetchBoard())
	}

	const HandlePlateClick = (cellIndex: number, rowIndex: number) => {
		console.log(`${cellIndex + 1} ${rowIndex + 1}`)
		dispatch(fetchBoard())
	}

	return (
		<div className='flex justify-center items-center w-screen'>
			<button onClick={HandleStart}>start</button>
			{board.length != 0 ? (
				<div>
					{board.map((row, rowIndex) => (
						<div key={rowIndex} className='flex'>
							{row.map((cell, cellIndex) => (
								<span
									className={`w-[60px] h-[60px] border border-black
                              ${cell == 'Empty' ? 'bg-slate-300' : 'bg-red-300'}
                               text-black flex items-center justify-center border border-gray-300`}
									key={cellIndex}
									onClick={() => HandlePlateClick(cellIndex, rowIndex)}
								></span>
							))}
						</div>
					))}
				</div>
			) : (
				<div>Some error</div>
			)}
		</div>
	)
}

export default App
