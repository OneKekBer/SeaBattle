import { v4 as uuidv4 } from 'uuid'
import Panel from './components/Panel'
import { convertStringToArray } from './helpers/Converter'

const App = () => {
	const board = convertStringToArray({
		board: 'Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty ContainsShip Empty Empty Empty Empty Empty ContainsShip Empty Empty Empty Empty Empty Empty Empty Empty Empty ContainsShip ContainsShip ContainsShip ContainsShip Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty Empty ',
	})

	const HandleStart = async () => {
		try {
			// Log the clicked coordinates (adjusting for 1-based index)

			// Send POST request to shoot endpoint
			const res = await fetch(`${import.meta.env.VITE_API_URL}restart`, {
				method: 'PUT',
			})

			// Check if request was successful
			if (!res.ok) {
				throw new Error('Problem with fetch shoot')
			}

			// Dispatch fetchBoard action to update the board state
			window.location.reload()
		} catch (error) {
			console.error('Error handling plate click:', error)
			// Handle errors, such as displaying an error message or logging
		}
	}

	return (
		<div className='flex items-center justify-center w-screen'>
			<button onClick={HandleStart}>restart</button>
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
				<div>Some error</div>
			)}
		</div>
	)
}

export default App
