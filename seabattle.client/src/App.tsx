import { v4 as uuidv4 } from 'uuid'
import Panel from './components/Panel'
import { convertStringToArray } from './helpers/Converter'
import { useEffect, useState } from 'react'

const App = () => {
	const board = convertStringToArray({
		board: 'Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty Empty Empty Empty Empty Empty Empty Empty ContainsShip ContainsShip ContainsShip ContainsShip Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty ',
	})
	const [isStartButtonPressed, setIsStartButtonPressed] = useState(false)

	const HandleRestart = async () => {
		try {
			const res = await fetch(`${import.meta.env.VITE_API_URL}restart`, {
				method: 'PUT',
			})

			if (!res.ok) {
				throw new Error('Problem with fetch shoot')
			}

			window.location.reload()
		} catch (error) {
			console.error('Error handling plate click:', error)
			// Handle errors, such as displaying an error message or logging
		}
	}
	const HandleStart = async () => {
		try {
			const res = await fetch(`${import.meta.env.VITE_API_URL}start`, {
				method: 'PUT',
			})

			if (!res.ok) {
				throw new Error('Problem with fetch shoot')
			}
			setIsStartButtonPressed(true)
		} catch (error) {
			console.error('Error handling plate click:', error)
			// Handle errors, such as displaying an error message or logging
		}
	}

	useEffect(() => {
		console.log('useeffect works')
	}, [])

	return (
		<div className=''>
			<h1 className='font-bold text-center'>Welcome to seabattle!!</h1>
			<h2 className='font-bold text-center'>Press start!!</h2>
			<h2 className='font-bold text-center'>
				If nothing happens press restart!
			</h2>
			<div className='flex flex-col items-center justify-center w-screen'>
				<div className='flex'>
					<button className='' onClick={HandleRestart}>
						restart
					</button>
					<button
						className=''
						disabled={isStartButtonPressed}
						onClick={HandleStart}
					>
						start
					</button>
				</div>
				{board.length != 0 ? (
					<div>
						{board.map((row, rowIndex) => (
							<div key={rowIndex} className='flex'>
								{row.map((cell, cellIndex) => (
									// <span
									// 	className={`w-[50px] h-[50px] border border-gray-400 cursor-pointer
									//       ${
									// 			cell == 'Empty'
									// 				? 'bg-slate-200'
									// 				: cell == 'Miss'
									// 				? 'bg-yellow-200'
									// 				: cell == 'Shooted'
									// 				? 'bg-red-500'
									// 				: 'bg-slate-200'
									// 		}
									//        text-black flex items-center justify-center border`}
									// 	key={cellIndex}
									// 	onClick={() => handlePlateClick(cellIndex, rowIndex)}
									// ></span>
									<Panel
										key={uuidv4()}
										cellIndex={cellIndex}
										rowIndex={rowIndex}
									/>
								))}
							</div>
						))}
					</div>
				) : (
					<div className='text-red-500'>Some error or press start</div>
				)}
			</div>
		</div>
	)
}

export default App
